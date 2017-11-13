$(document).ready(function () {
    GetAllFeaturedPosts();
	getAllBlogPosts();
	getAllBlogPostsFiltered();
	clearFiltersForAllBlogs();
	deleteADrraft();
	getAllAuthorBlogs();
	getAllFilteredAuthorBlogs();
	clearFiltersForAdminSearch();
	//removeABlogPost();
	getBlogPostsByOneAuthor();
	getFilteredBlogPostsByOneAuthor();
});


//INDEX/HOME PAGE!
function GetAllFeaturedPosts()
{
    $.ajax({
        type: "GET",
        url: "http://localhost:62645/blogs/featured",
        success: function (blogPostArray) {
            //alert("success")
            $(".allBlogs").show();
            $(".filteredBlogs").hide();

            var allBlogPosts = $("#featuredBlogs");

            $.each(blogPostArray, function (index, blogPost) {

				var blogPostInfo = '<p style="font-weight:bolder; font-size:30px">' + blogPost.title + '</p>' +
                    '<p>' + "By " + blogPost.user.firstName + " " + blogPost.user.lastName + " " + blogPost.dateStart + '</p>';


                allBlogPosts.append(blogPostInfo);

                $.each(blogPost.hashtags, function (index, hashtags) {
                    var hashtagInfo = hashtags.hashtagName + " ";

                    allBlogPosts.append(hashtagInfo);
                });

                var moreBlogPostInfo = '<p>' + blogPost.blogContent + '</p><hr/>';

				allBlogPosts.append(moreBlogPostInfo);

            });

        },
        error: function () {
            //alert("error")
        }
    });
}


//BLOGS PAGE WHEN LOADED!
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

				var blogPostInfo = '<p style="font-weight:bolder; font-size:30px">' + blogPost.title + '</p>' +
                    '<p>' + "By " + blogPost.user.firstName + " " + blogPost.user.lastName + " " + blogPost.dateStart + '</p>';


                allBlogPosts.append(blogPostInfo);

                $.each(blogPost.hashtags, function (index, hashtags) {
                    var hashtagInfo = hashtags.hashtagName + " ";

                    allBlogPosts.append(hashtagInfo);
                });


				var moreBlogPostInfo = '<div></br></div>' + '<p>' + blogPost.blogContent + '</p><hr />'; 

				allBlogPosts.append(moreBlogPostInfo);

			});

		},
		error: function () {
			//alert("error")
		}
	});
}

//BLOGS PAGE WHEN FILTERED!
function getAllBlogPostsFiltered() {
	$("#search-blog-button").on("click", function () {
		
		var searchTermInput = $("#searchCategoryInput").val();
		var searchTermCategory = $("#searchCategoryDropList").val();

		if (searchTermInput[0] == "#") {
			var searchTermInput = searchTermInput.replace("#", "")
		}

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

						var blogPostInfo = '<p style="font-weight:bolder; font-size:30px">' + blogPost.title + '</p>' +
							'<p>' + "By " + blogPost.user.firstName + " " + blogPost.user.lastName + " " + blogPost.dateStart + '</p>';
							
						blogsBySearchFilter.append(blogPostInfo)

						$.each(blogPost.hashtags, function (index, hashtags) {
							var hashtagInfo = hashtags.hashtagName + " "

							blogsBySearchFilter.append(hashtagInfo);
						});

						var moreBlogPostInfo = '<div></br></div>' + '<p>' + blogPost.blogContent + '</p>' +
							'<p><button class="btn btn-danger" id="EditBlogPostBtn" data-blogpostid="' + blogPost.blogPostId + '">Edit Blog Post</button>' + " " +
							'<button class="btn btn-danger" id="DeleteBlogPostBtn" data-blogpostid="' + blogPost.blogPostId + '">Delete Blog Post</button></p><hr/>';
                                              

						blogsBySearchFilter.append(moreBlogPostInfo);
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

//BLOGS PAGE WHEN CLEARING!
function clearFiltersForAllBlogs() {
	$("#clear-filters-button").on("click", function () {
		$(".filteredBlogs").hide();
		$(".allBlogs").show();
		$("#searchCategoryDropList").val('none');
		$("#searchCategoryInput").val("");
	});
}

//MY BLOGS PAGE WHEN LOADED!
function getBlogPostsByOneAuthor() {

	$(".allBlogsByAuthor").show();
	$(".filteredBlogsByAuthor").hide();
	$(".filteredBlogsByAuthor").text("");

	var authUserName = $("#forTheLoveOfGodWork").val();

	authUserName = authUserName.replace(/([A-Z])/g, ' $1').trim();
	

	$.ajax({
		type: "GET",

		//need to change this URL path to reflect the user signed in at some point
		url: "http://localhost:62645/blogs/author/" + authUserName + "/all",
		success: function (blogPostArray) {
			//alert("success")
			var allBlogsHere = $(".allBlogsByAuthor");

			$.each(blogPostArray, function (index, blogPost) {

				var blogPostInfo = '<p style="color:red; font-weight:bolder">' + blogPost.blogStatus.blogStatusDescription + '</p>' +
					'<p style="font-weight:bolder; font-size:30px">' + blogPost.title + '</p>' +
					'<p>' + "By " + blogPost.user.firstName + " " + blogPost.user.lastName + " " + blogPost.dateStart + '</p>';

				allBlogsHere.append(blogPostInfo);

				$.each(blogPost.hashtags, function (index, hashtags) {
					var hashtagInfo = hashtags.hashtagName + " ";

					allBlogsHere.append(hashtagInfo);
				});

				var moreBlogPostInfo = '<div></br></div>' + '<p>' + blogPost.blogContent + '</p>' +

                    '<p><input type="button" class="btn btn-primary" onClick="location.href=\'Edit/' + blogPost.blogPostId + '\'" value="Edit Post">' + " ";

				allBlogsHere.append(moreBlogPostInfo);

				if (blogPost.blogStatus.blogStatusDescription == "Draft") {
					var mooooreStuff = '<button class="btn btn-danger" id="DeleteMyBlogPostBtn" data-blogpostid="' + blogPost.blogPostId + '">Delete Blog Post</button></p><hr/>';

					allBlogsHere.append(mooooreStuff);
				}
				if (blogPost.blogStatus.blogStatusDescription == "Published" || blogPost.blogStatus.blogStatusDescription == "Pending") {
					var moooooreStuff = '</p><hr />'

					allBlogsHere.append(moooooreStuff);
				}
			});
		},
		error: function () {
			//alert("error")
		}
	});
}

//MY BLOG PAGE WHEN FILTERED!
function getFilteredBlogPostsByOneAuthor() {
	$("#search-blogByAuthor-button").on("click", function () {

		var searchPostStatus = $("#searchPostStatus").val();
		var status = "";

		if (searchPostStatus == "myPublished") {
			status = "";
		}
		if (searchPostStatus == "myPending") {
			status = "/pending";
		}
		if (searchPostStatus == "myDraft") {
			status = "/drafts";
		}
		if (searchPostStatus == "allMyPosts") {
			status = "/all";
		}

		$(".allBlogsByAuthor").hide();
		$(".filteredBlogsByAuthor").show();
		$(".filteredBlogsByAuthor").text("");

		var authUserName = $("#forTheLoveOfGodWork").val();

		authUserName = authUserName.replace(/([A-Z])/g, ' $1').trim();

		$.ajax({
			type: "GET",

			//need to change this URL path to reflect the user signed in at some point
			url: "http://localhost:62645/blogs/author/" + authUserName + status,
			success: function (blogPostArray) {
				//alert("success")
				var filteredBlogsHere = $(".filteredBlogsByAuthor");

				$.each(blogPostArray, function (index, blogPost) {

					var blogPostInfo = '<p style="color:red; font-weight:bolder">' + blogPost.blogStatus.blogStatusDescription + '</p>' +
						'<p style="font-weight:bolder; font-size:30px">' + blogPost.title + '</p>' +
						'<p>' + "By " + blogPost.user.firstName + " " + blogPost.user.lastName + " " + blogPost.dateStart + '</p>';

					filteredBlogsHere.append(blogPostInfo);

					$.each(blogPost.hashtags, function (index, hashtags) {
						var hashtagInfo = hashtags.hashtagName + " ";

						filteredBlogsHere.append(hashtagInfo);
					});

					var moreBlogPostInfo = '<div></br></div>' + '<p>' + blogPost.blogContent + '</p>' +

                        '<p><input type="button" class="btn btn-primary" onClick="location.href=\'Edit/' + blogPost.blogPostId + '\'" value="Edit Post">' + " ";

					filteredBlogsHere.append(moreBlogPostInfo);

					if (blogPost.blogStatus.blogStatusDescription == "Draft") {
						var mooooreStuff = '<button class="btn btn-danger" id="DeleteMyBlogPostBtn" data-blogpostid="' + blogPost.blogPostId + '">Delete Blog Post</button></p><hr/>';

						filteredBlogsHere.append(mooooreStuff);
					}
					if (blogPost.blogStatus.blogStatusDescription == "Published" || blogPost.blogStatus.blogStatusDescription == "Pending") {
						var moooooreStuff = '</p><hr />'

						filteredBlogsHere.append(moooooreStuff);

					}
				});
			},
			error: function () {
				//alert("error")
			}
		});
	});
}

//MY BLOGS PAGE WHEN DELETING A DRAFT (REAL DELETE) 
function deleteADrraft() {

	//by delete, we actually mean change status to removed

	$(document).on("click", "#DeleteMyBlogPostBtn", function () {
		var blogPostId = $(this).data('blogpostid');

		$.ajax({
			type: "DELETE",
			url: "http://localhost:62645/blog/" + "delete/" + blogPostId,
			success: function () {
				alert("success")
				$(".allBlogsByAuthor").text("");
				$(".filteredBlogsByAuthor").text("");
				getBlogPostsByOneAuthor();
			},
			error: function () {
				alert("error")
			}
		});
	});
}

//ADMIN PAGE WHEN LOADED!
function getAllAuthorBlogs() {
	var searchTermInput = $("#searchStatusList").val();
	var searchTermCategory = $("#searchStatusList").val();

	$(".allAuthorBlogs").show();
	$(".filteredAuthorBlogs").hide();
	$(".filteredAuthorBlogs").text("");
	$.ajax({
		type: "GET",
		url: "http://localhost:62645/blogs/nondraft",
		success: function (blogPostArray) {

			var allAuthorBlogs = $(".allAuthorBlogs");

			$.each(blogPostArray, function (index, blogPost) {

				var blogPostInfo = '<p style="color:red; font-weight:bolder">' + blogPost.blogStatus.blogStatusDescription + '</p>' +
					'<p style="font-weight:bolder; font-size:30px">' + blogPost.title + '</p>' +
					'<p>' + "By " + blogPost.user.firstName + " " + blogPost.user.lastName + " " + blogPost.dateStart + '</p>';

				allAuthorBlogs.append(blogPostInfo);

				$.each(blogPost.hashtags, function (index, hashtags) {
					var hashtagInfo = hashtags.hashtagName + " ";

					allAuthorBlogs.append(hashtagInfo);
				});

				var moreBlogPostInfo = '<div></br></div>' + '<p>' + blogPost.blogContent + '</p>' +

                    '<p><input type="button" class="btn btn-primary" onClick="location.href=\'Edit/' + blogPost.blogPostId + '\'" value="Edit Post">' + " " +
					'<button class="btn btn-danger" id="DeleteBlogPostBtn" data-blogpostid="' + blogPost.blogPostId + '">Delete Blog Post</button></p><hr/>';

				allAuthorBlogs.append(moreBlogPostInfo);
			});
			//alert("success")
		},
		error: function () {
			//alert("error")
		}
	});
}

//ADMIN PAGE WHEN FILTERED!
function getAllFilteredAuthorBlogs() {
	$("#adminSearch-blog-button").on("click", function () {

		var searchPostStatus = $("#searchStatusList").val();
		var filterBy = $("#filterByList").val();
		var restOfPath = "";
		var inputForAdminSearch = $("#inputForAdminSearch").val();

		$(".allAuthorBlogs").hide();
		$(".filteredAuthorBlogs").show();
		$(".filteredAuthorBlogs").text("");

		//all post status types
		if (searchPostStatus == "allAuthorPosts") {
			if (filterBy == "blogAllAuthors") {
				restOfPath = "/nondraft";
			}
			else if (filterBy == "blogAuthorName") {
				//still need to change it so user isn't hardcoded in
				restOfPath = "/author/" + inputForAdminSearch + "/nondraft";
			}
		}
		//published status 
		else if (searchPostStatus == "AuthorPublishedPosts") {
			if (filterBy == "blogAllAuthors") {
				restOfPath = "/published";
			}
			else if (filterBy == "blogAuthorName") {
				//still need to change it so user isn't hardcoded in
				restOfPath = "/author/" + inputForAdminSearch;
			}
		}
		//pending status
		else if (searchPostStatus == "AuthorPendingPosts") {
			if (filterBy == "blogAllAuthors") {
				restOfPath = "/pending";
			}
			else if (filterBy == "blogAuthorName") {
				restOfPath = "/author/" + inputForAdminSearch + "/pending";
			}
		}
		//removed posts
		else if (searchPostStatus == "AuthorRemovedPosts") {
			if (filterBy == "blogAllAuthors") {
				restOfPath = "/removed";
			}
			else if (filterBy == "blogAuthorName") {
				restOfPath = "/author/" + inputForAdminSearch + "/removed"
			}
		}

		$.ajax({
			type: "GET",

			//need to change this URL path to reflect the user signed in at some point
			url: "http://localhost:62645/blogs" + restOfPath,
			success: function (blogPostArray) {
				//alert("success")
				var filteredBlogsHere = $(".filteredAuthorBlogs");

				$.each(blogPostArray, function (index, blogPost) {

                    var thisDate = blogPost.dateStart;
                    var month = Date.prototype.getMonth(thisDate);
                    var date = Date.prototype.getDate(thisDate);
                    var year = Date.prototype.getFullYear(thisDate);

					var blogPostInfo = '<p style="color:red; font-weight:bolder">' + blogPost.blogStatus.blogStatusDescription + '</p>' +
						'<p style="font-weight:bolder; font-size:30px">' + blogPost.title + '</p>' +
						'<p>' + "By " + blogPost.user.firstName + " " + blogPost.user.lastName + " " + date + '</p>';

					filteredBlogsHere.append(blogPostInfo)

					$.each(blogPost.hashtags, function (index, hashtags) {
						var hashtagInfo = hashtags.hashtagName + " ";

						filteredBlogsHere.append(hashtagInfo);
					});

					var moreBlogPostInfo = '<div></br></div>' + '<p>' + blogPost.blogContent + '</p>' +

                        '<p><input type="button" class="btn btn-primary" onClick="location.href=\'Edit/' + blogPost.blogPostId + '\'" value="Edit Post">' + " " +
						'<button class="btn btn-danger" id="DeleteBlogPostBtn" data-blogpostid="' + blogPost.blogPostId + '">Delete Blog Post</button></p><hr/>';

					filteredBlogsHere.append(moreBlogPostInfo);
				});
			},
			error: function () {
				//alert("error")
			}
		});
	})
}

//ADMIN PAGE WHEN CLEARING
function clearFiltersForAdminSearch() {
	$("#clear-adminFilters-button").on("click", function () {
		$(".filteredAuthorBlogs").hide();
		$(".allAuthorBlogs").show();
		$("#searchStatusList").val("allAuthorPosts");
		$("#filterByList").val("blogAllAuthors");
		$("#inputForAdminSearch").val("");
	});
}

//ADMIN PAGE WHEN REMOVING A BLOGPOST (SWITCHING STATUS TO REMOVED)
function removeABlogPost() {

	//by delete, we actually mean change status to removed

	$(document).on("click", "#DeleteBlogPostBtn", function () {
		var blogPostId = $(this).data('blogpostid');

		$.ajax({
			type: "PUT",
			url: "http://localhost:62645/blog/" + "remove/" + blogPostId,
			success: function () {
				//alert("success")
				searchBySomething();
			},
			error: function () {
				//alert("error")
			}
		});
	});
}
