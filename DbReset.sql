USE TechTruffleShuffle
GO

if exists(Select * From INFORMATION_SCHEMA.Routines
where routine_name = 'DbReset')
drop procedure DbReset
go 

Create Procedure DbReset As
Begin

	Delete from BlogStatus;
	Delete from BlogCategories;
	Delete from Hashtags;
	Delete from Authors;
	Delete from BlogPosts;
	Delete from HashTagBlogPosts;

	DBCC CHECKIDENT ('Authors', reseed, 1)
	Set Identity_Insert Authors on;
		insert into Authors(AuthorId, FirstName, LastName)
		Values(1, 'Judy', 'Thao'),
		(2, 'Lindsey', 'Parlow'),
		(3, 'Aj', 'Rohde')
	Set Identity_Insert Authors off;

	DBCC CHECKIDENT ('Hashtags', reseed, 1)
	Set Identity_Insert Hashtags on;
		insert into Hashtags(HashtagId, HashtagName)
		Values(1, '#VirtualReality'),
		(2, '#MobileDevelopment'),
		(3, '#Angular'),
		(4, '#Hack')
	Set Identity_Insert Hashtags off;

	DBCC CHECKIDENT ('BlogCategories', reseed, 1)
	Set Identity_Insert BlogCategories on;
		insert into BlogCategories(BlogCategoryId, BlogCategoryName)
		Values(1, 'Technical'),
		(2, 'Social'),
		(3, 'Networking'),
		(4, 'Other')
	Set Identity_Insert BlogCategories off;

	DBCC CHECKIDENT ('BlogStatus', reseed, 1)
	Set Identity_Insert BlogStatus on;
		insert into BlogStatus(BlogStatusId, BlogStatusDescription)
		Values(1, 'Draft'),
		(2, 'Pending'),
		(3, 'Published')
	Set Identity_Insert BlogStatus off;

	DBCC CHECKIDENT ('BlogPosts', reseed, 1)
	Set Identity_Insert BlogPosts on;
		insert into BlogPosts(BlogPostId,  Title, EventDate, AuthorId, BlogContent, DateStart, DateEnd, BlogCategoryId, BlogStatusId, IsFeatured, IsStaticPage, IsRemoved )
		Values(1, 'JavaScriptMn, Monthly Meet Up', '10/27/2017', 1, 'At tonights event we learned about Angular Universal and server side rendering', '10/26/2017', '10/26/2018', 1, 1, 1, 0, 0 ),
		(2, 'Hack-o-Thon', '10/31/017', 2, 'A haunting night with the annual Hack-o-Thon hostsed by Target Virtual Reality department. We were able to tour a haunting house', '11/01/2017', '02/28/2018', 4, 3, 1, 0, 0 ),
		(3, 'Grace Hopper Viewing party','10/27/2017', 1, 'At tonights events we learned about Angular Universal and server side rendering', '10/26/2017', '10/26/2018', 1, 1, 1, 0, 0 )
	Set Identity_Insert BlogPosts off;

	--DBCC CHECKIDENT ('HashtagBlogPosts', reseed, 1)
	--Set Identity_Insert HashtagBlogPosts on;
		insert into HashTagBlogPosts(Hashtag_HashtagId, BlogPost_BlogPostId)
		Values(1, 1),
		(1, 2),
		(1, 3)
	--Set Identity_Insert HashtagBlogPosts off;

End