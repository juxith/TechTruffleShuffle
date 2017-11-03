$(document).ready(function () {
	//loadFilteredBlogs();
	//makeItDoStuff();
	searchBySomething();
	//formatDate()
});

function loadFilteredBlogs() {





	$("#search-blog-button").on("click", function () {
		if ($("#searchCategoryDropList").val() == "title") {
			$(".allBlogs").hide();
			$(".filteredBlogs").text();
		}
	});
}

function formatDate(date) {
	var monthNames = [
		"January", "February", "March",
		"April", "May", "June", "July",
		"August", "September", "October",
		"November", "December"
	];

	var day = date.getDate();
	var monthIndex = date.getMonth();
	var year = date.getFullYear();

	return day + ' ' + monthNames[monthIndex] + ' ' + year;
}

function searchBySomething() {
	$("#search-blog-button").on("click", function () {
		
		var searchTermInput = $("#thisThing").val();
		var searchTermCategory = $("#searchCategoryDropList").val();
		//if ($("#searchCategoryDropList").val() != "") {
			$(".allBlogs").hide();
			$(".filteredBlogs").text("");
			$.ajax({
				type: "GET",
				url: "http://localhost:62645/blogs/" + searchTermCategory + "/" + searchTermInput,
				success: function (blogPostArray) {
					var blogsBySearchFilter = $(".filteredBlogs");
					var clearTheDiv = "";
					$.each(blogPostArray, function (index, blogPost) {

				

						var blogPostInfo = '<p>' + blogPost.title + '</p>' +
							'<p>' + "By " + blogPost.user.firstName + " " + blogPost.user.lastName + " " + blogPost.dateStart + '</p>' +
							'<p>' + blogPost.blogContent + '</p>' +
							'<p><button class="btn btn-danger" id="adminEditBlogPostBtn">Edit Blog Post</button></p>' +
							'<p><button class="btn btn-danger" id="adminDeleteBlogoPostBtn">Delete Blog Post</button></p>' +

							$.each(blogPostArray.hashtags, function (index, hashtags) {
								var hashtagInfo = '<p>' + hashtags.hashtagName + '<p>'
							})
						
						blogsBySearchFilter.append(blogPostInfo)

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


function makeItDoStuff() {
	
	$("#search-blog-button").on("click", function () {
		$("#thisThing").val("hello");
	})
}

//" " + date.getDate() +
//var date = new Date(blogPost.dateStart);