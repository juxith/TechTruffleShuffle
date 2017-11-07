$(document).ready(function () {
	//makeItDoStuff();
	getAllBlogPosts();
	getAllBlogPostsFiltered();
	clearFiltersForAllBlogs();
	//deleteStuff();
	getBlogPostsByOneAuthor();

});

function getAllBlogPosts() {
	$.ajax({
		type: "GET",
		url: "http://localhost:62645/blogs/published",
		success: function (blogPostArray) {
			//alert("success")
			$(".allBlogs").show();
			$(".filteredBlogs").hide();

			var allBlogPosts = $(".allBlogs");

			$.each(blogPostArray, function (index, blogPost) {

				var blogPostInfo = '<p>' + blogPost.title + '</p>' +
					'<p>' + "By " + blogPost.user.firstName + " " + blogPost.user.lastName + " " + blogPost.dateStart + '</p>'


				allBlogPosts.append(blogPostInfo)

				$.each(blogPost.hashtags, function (index, hashtags) {
					var hashtagInfo = hashtags.hashtagName + " "

					allBlogPosts.append(hashtagInfo)
				})

				var moreBlogPostInfo = '<p>' + blogPost.blogContent + '</p>' +
					'<p><button class="btn btn-danger" id="EditBlogPostBtn" data-blogpostid="' + blogPost.blogPostId + '">Edit Blog Post</button></p>' +
					'<p><button class="btn btn-danger" id="DeleteBlogPostBtn" data-blogpostid="' + blogPost.blogPostId + '">Delete Blog Post</button></p>'

				allBlogPosts.append(moreBlogPostInfo)

			});

		},
		error: function () {
			alert("error")
		}
	});
}

function getAllBlogPostsFiltered() {
	$("#search-blog-button").on("click", function () {
		
		var searchTermInput = $("#searchCategoryInput").val();
		var searchTermCategory = $("#searchCategoryDropList").val();

		$(".allBlogs").hide();
		$(".filteredBlogs").show();
			$(".filteredBlogs").text("");
			$.ajax({
				type: "GET",
				url: "http://localhost:62645/blogs/" + searchTermCategory + "/" + searchTermInput,
				success: function (blogPostArray) {

					var blogsBySearchFilter = $(".filteredBlogs");
					var clearTheDiv = "";
					$.each(blogPostArray, function (index, blogPost) {

						var blogPostInfo = '<p>' + blogPost.title + '</p>' +
							'<p>' + "By " + blogPost.user.firstName + " " + blogPost.user.lastName + " " + blogPost.dateStart + '</p>' 
							
						blogsBySearchFilter.append(blogPostInfo)

						$.each(blogPost.hashtags, function (index, hashtags) {
							var hashtagInfo = hashtags.hashtagName + " "

							blogsBySearchFilter.append(hashtagInfo)
						})

						var moreBlogPostInfo = '<p>' + blogPost.blogContent + '</p>' +
							'<p><button class="btn btn-danger" id="EditBlogPostBtn" data-blogpostid="' + blogPost.blogPostId + '">Edit Blog Post</button></p>' +
							'<p><button class="btn btn-danger" id="DeleteBlogPostBtn" data-blogpostid="'+ blogPost.blogPostId +'">Delete Blog Post</button></p>'

						blogsBySearchFilter.append(moreBlogPostInfo)
					});
					//alert("success")
				},
				error: function () {
					//alert("error")
				}
			});
		}
	);
}

function clearFiltersForAllBlogs() {
	$("#clear-filters-button").on("click", function () {
		$(".filteredBlogs").hide();
		$(".allBlogs").show();
		$("#searchCategoryDropList").val('none');
		$("#searchCategoryInput").val("");
	});
}

//need to work with this more
function deleteStuff() {

	//by delete, we actually mean change status to removed

	$(document).on("click", "#DeleteBlogPostBtn", function () {
		var blogPostId = $(this).data('blogpostid');

		$.ajax({
			type: "PUT",
			url: "http://localhost:62645/blog/" + "remove/" + blogPostId,
			success: function () {
				alert("success")
				searchBySomething();
			},
			error: function () {
				alert("error")
			}
		});
	})
}

function getBlogPostsByOneAuthor() {

	var searchTermCategory = $("#searchCategoryDropList").val();

	$(".allBlogsByAuthor").show();
	$(".filteredBlogsByAuthor").hide();
	$(".filteredBlogsByAuthor").text("");
	$.ajax({
		type: "GET",
		url: "http://localhost:62645/blogs/author/" + "LindseyParlow" + "/" + searchPostStatus,
		success: function (blogPostArray) {
			alert("success")
			var blogsBySearchFilter = $(".filteredBlogsByAuthor");

			$.each(blogPostArray, function (index, blogPost) {

				var blogPostInfo = '<p>' + blogPost.title + '</p>' +
					'<p>' + "By " + blogPost.user.firstName + " " + blogPost.user.lastName + " " + blogPost.dateStart + '</p>'

				blogsBySearchFilter.append(blogPostInfo)

				$.each(blogPost.hashtags, function (index, hashtags) {
					var hashtagInfo = hashtags.hashtagName + " "

					blogsBySearchFilter.append(hashtagInfo)
				})

				var moreBlogPostInfo = '<p>' + blogPost.blogContent + '</p>' +
					'<p><button class="btn btn-danger" id="EditBlogPostBtn" data-blogpostid="' + blogPost.blogPostId + '">Edit Blog Post</button></p>' +
					'<p><button class="btn btn-danger" id="DeleteBlogPostBtn" data-blogpostid="' + blogPost.blogPostId + '">Delete Blog Post</button></p>'

				blogsBySearchFilter.append(moreBlogPostInfo)
			});
		},
		error: function () {
			alert("error")
		}
	});
}






function makeItDoStuff() {
	
	$("#search-blog-button").on("click", function () {
		$("#thisThing").val("hello");
	})
}


