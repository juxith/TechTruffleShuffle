$(document).ready(function () {
	loadFeaturedBlogs();
});

function loadFeaturedBlogs() {
	$.ajax({
		type: "GET",
		url: "http://localhost:6245/blogs/featured",
		success: function (blogArray) {
			var blogPosts = $("#featuredBlogs");
			$.each(itemArray, function (index, blog) {

				var featuredBlogInfo = '<div class="col-md-12 blogToGrab" data-id="' + blog.id + '"><p>' + blog.title + "</p>" +
					"<p>" + blog.hashtags + "</p>" +
					"<p>" + blog.blogContent + "</p>" +
					"</p></div";

				blogPosts.append(featuredBlogInfo)
			});
}