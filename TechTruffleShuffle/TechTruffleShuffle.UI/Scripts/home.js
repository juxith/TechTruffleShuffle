$(document).ready(function() {
    loadFeaturedBlogs();
    //makeItDoStuff();
});

function loadFeaturedBlogs() {

    var itemNumber = $('#featuredBlogs');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:62645/blogs/featured',
        success: function(blogArray) {
            $.each(blogArray, function(index, blogPost) {

                var title = blogPost.title;
                var content = blogPost.blogPost.blogContent;

                var row = '<tr>';
                row += '<td>' + title + '</td>';
                row += '<td>' + content + '</td>';
                row += '</tr>';

                itemNumber.append(row);
            });
        },
        error: function() {
            alert("error")
        }
    });
}


function makeItDoStuff() {
    var featured = "this is some featured stuff";
    $("#needToClickThis").on("click", function() {
        $("#featuredBlogPosts").val(featured);
    })
}
