USE TechTruffleShuffle
GO

if exists(Select * From INFORMATION_SCHEMA.Routines
where routine_name = 'ReseedScript')
drop procedure ReseedScript
go 

Create Procedure ReseedScript As
Begin

	Delete from BlogStatus;
	Delete from BlogCategories;
	Delete from Hashtags;
	Delete from BlogPosts;
	Delete from HashTagBlogPosts;
	
	DBCC CHECKIDENT ('Hashtags', reseed, 0)
	

	DBCC CHECKIDENT ('BlogCategories', reseed, 0)


	DBCC CHECKIDENT ('BlogStatus', reseed, 0)


	DBCC CHECKIDENT ('BlogPosts', reseed, 0)

end
