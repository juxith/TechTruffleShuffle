using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTruffleShuffle.Data;
using TechTruffleShuffle.Models;

namespace TechTruffleShuffle.Tests
{
    [TestFixture]
    public class EFTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["TechTruffleShuffle"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void EFCanGetAllPosts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var blogPosts = repo.GetAllPosts();

            Assert.AreEqual(3, blogPosts.Count);
            Assert.AreEqual(4, blogPosts[1].BlogCategoryId);
            Assert.AreEqual(3, blogPosts[1].BlogStatusId);
            Assert.IsTrue(blogPosts[1].IsFeatured);
        }

        [Test]
        public void EFCanCreateNewBlogPost()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            BlogPost newBlogPost = new BlogPost();

            newBlogPost.Title = "Hey, This New Post!";
            newBlogPost.BlogContent = "Code and Talk and Code and Talk and Code and Talk. Success!";
            newBlogPost.EventDate = new DateTime(2017, 10, 30);
            newBlogPost.DateStart = new DateTime(2017, 11, 01);
            newBlogPost.DateEnd = new DateTime(2018, 01, 01);
            newBlogPost.BlogCategoryId = 2;
            newBlogPost.BlogStatusId = 2;
            newBlogPost.IsFeatured = false;
            newBlogPost.IsStaticPage = false;
            newBlogPost.IsRemoved = false;
 
            repo.CreateNewBlogPost(newBlogPost);

            Assert.AreEqual(4, newBlogPost.BlogPostId);
        }

        [Test]
        public void EFCanDeleteBlogPost()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            //add a blogpost first so I can try deleting it in the next step
            BlogPost newBlogPost = new BlogPost();

            newBlogPost.Title = "Hey, This New Post!";
            newBlogPost.BlogContent = "Code and Talk and Code and Talk and Code and Talk. Success!";
            newBlogPost.EventDate = new DateTime(2017, 10, 30);
            newBlogPost.DateStart = new DateTime(2017, 11, 01);
            newBlogPost.DateEnd = new DateTime(2017, 01, 01);
            newBlogPost.BlogCategoryId = 2;
            newBlogPost.BlogStatusId = 2;
            newBlogPost.IsFeatured = false;
            newBlogPost.IsStaticPage = false;
            newBlogPost.IsRemoved = false;

            //check to make sure it added ok
            repo.CreateNewBlogPost(newBlogPost);
            var addBlog = repo.GetAllPosts();

            Assert.IsNotNull(addBlog[3]);

            //check to make sure that it deleted ok
            repo.DeleteBlogPost(4);
            var deleteThis = repo.GetAllPosts();
            Assert.IsNull(deleteThis[3]);
        }

        [Test]
        public void EFCanEditBlogPost()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            BlogPost newBlogPost = new BlogPost();

            newBlogPost.Title = "Hey, This New Post!";
            newBlogPost.BlogContent = "Code and Talk and Code and Talk and Code and Talk. Success!";
            newBlogPost.EventDate = new DateTime(2017, 10, 30);
            newBlogPost.DateStart = new DateTime(2017, 11, 01);
            newBlogPost.DateEnd = new DateTime(17, 12, 01);
            newBlogPost.BlogCategoryId = 2;
            newBlogPost.BlogStatusId = 2;
            newBlogPost.IsFeatured = false;
            newBlogPost.IsStaticPage = false;
            newBlogPost.IsRemoved = false;
            newBlogPost.Hashtags = null;

            repo.CreateNewBlogPost(newBlogPost);

            newBlogPost.Title = "Hey, This Post Was Updated!";
            newBlogPost.BlogContent = "Code, Code, Talk. Code, Code, Talk. Brilliant!";
            newBlogPost.EventDate = new DateTime(2017, 10, 30);
            newBlogPost.DateStart = new DateTime(2017, 11, 03);
            newBlogPost.DateEnd = new DateTime(17, 12, 03);
            newBlogPost.BlogCategoryId = 2;
            newBlogPost.BlogStatusId = 2;
            newBlogPost.IsFeatured = true;
            newBlogPost.IsStaticPage = false;
            newBlogPost.IsRemoved = false;
            newBlogPost.Hashtags = null;

            repo.EditBlogPost(newBlogPost);

            var editedBlogPost = repo.GetBlogPostById(5);

            Assert.AreEqual("Hey, This Post Was Updated!", editedBlogPost.Title);
            Assert.AreEqual(2, editedBlogPost.BlogCategoryId);
            Assert.IsTrue(editedBlogPost.IsFeatured);
        }

        [Test]
        public void EFCanGetAllDrafts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var drafts = repo.GetAllDrafts();

            Assert.AreEqual(2, drafts.Count);
            Assert.AreEqual(4, drafts[1].BlogPostId);
            Assert.AreEqual("Let's Get Together and Code", drafts[1].Title);
        }

        [Test]
        public void EFCanGetAllDraftsByOneAuthor()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var drafts = repo.GetAllDraftsByOneAuthor("Lindsey");

            Assert.AreEqual(1, drafts.Count);
            Assert.AreEqual(1, drafts[0].BlogPostId);
            Assert.AreEqual("Judy the Ruby Master", drafts[0].Title);
        }

        [Test]
        public void EFCanGetAllFeaturedPosts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var featuredPosts = repo.GetAllFeaturedPosts();

            Assert.AreEqual(1, featuredPosts.Count);
            Assert.AreEqual(2, featuredPosts[0].BlogPostId);
            Assert.AreEqual("Guide to Getting the Job", featuredPosts[0].Title);
        }

        [Test]
        public void EFCanGetAllPendingPosts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var pendingPosts = repo.GetAllPendingPosts();

            Assert.AreEqual(1, pendingPosts.Count);
            Assert.AreEqual(3, pendingPosts[0].BlogPostId);
            Assert.AreEqual("Tech Beers and Cheers", pendingPosts[0].Title);
        }

        [Test]
        public void EFCanGetAllPendingPostsByOneAuthor()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var pendingPosts = repo.GetAllPendingPostsByOneAuthor("AJ");

            Assert.AreEqual(1, pendingPosts.Count);
            Assert.AreEqual(3, pendingPosts[0].BlogPostId);
            Assert.AreEqual("Tech Beers and Cheers", pendingPosts[0].Title);

            var pendingPosts2 = repo.GetAllPendingPostsByOneAuthor("Judy");

            Assert.AreEqual(0, pendingPosts2.Count);
        }

        [Test]
        public void EFCanGetAllPublishedPosts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var publishedPosts = repo.GetAllPublishedPosts();

            Assert.AreEqual(1, publishedPosts.Count);
            Assert.AreEqual(2, publishedPosts[0].BlogPostId);
            Assert.AreEqual("Guide to Getting the Job", publishedPosts[0].Title);
        }

        [Test]
        public void EFCanGetAllPublishedPostsByAuthor()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var publishedPostsByOneAuthor = repo.GetAllPublishedPostsByAuthor("Judy Thao");

            Assert.AreEqual(1, publishedPostsByOneAuthor.Count);
            Assert.AreEqual(2, publishedPostsByOneAuthor[0].BlogPostId);
            Assert.AreEqual("Guide to Getting the Job", publishedPostsByOneAuthor[0].Title);
        }

        [Test]
        public void EFCanGetAllPublishedPostsByCategory()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var publishedPostsbyCategory = repo.GetAllPublishedPostsByCategory(3);

            Assert.AreEqual(1, publishedPostsbyCategory.Count);
            Assert.AreEqual(2, publishedPostsbyCategory[0].BlogPostId);
            Assert.AreEqual("Guide to Getting the Job", publishedPostsbyCategory[0].Title);

            var publishedPostsbyCategory2 = repo.GetAllPublishedPostsByCategory(2);

            Assert.AreEqual(0, publishedPostsbyCategory2.Count);
        }

        [Test]
        public void EFCanGetAllPublishedPostsByDate()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var publishedPostsbyDate = repo.GetAllPublishedPostsByDate("12/1/17");

            Assert.AreEqual(1, publishedPostsbyDate.Count);
            Assert.AreEqual(2, publishedPostsbyDate[0].BlogPostId);
            Assert.AreEqual("Guide to Getting the Job", publishedPostsbyDate[0].Title);

            var publishedPostsbyDate2 = repo.GetAllPublishedPostsByDate("10/31/17");

            Assert.AreEqual(0, publishedPostsbyDate2.Count);
        }

        [Test]
        public void EFCanGetAllPublishedPostsByHashtag()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var publishedPosts = repo.GetAllPublishedPostsByHashtag("#InItToWinIt");

            Assert.AreEqual(1, publishedPosts.Count);
            Assert.AreEqual(2, publishedPosts[0].BlogPostId);
            Assert.AreEqual("Guide to Getting the Job", publishedPosts[0].Title);
        }

        [Test]
        public void EFCanGetAllRemovedPosts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var removedPosts = repo.GetAllRemovedPosts();

            Assert.AreEqual(1, removedPosts.Count);
            Assert.AreEqual(4, removedPosts[0].BlogPostId);
            Assert.AreEqual("Let's Get Together and Code", removedPosts[0].Title);
        }

        [Test]
        public void EFCanGetAllStaticPages()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var staticPage = repo.GetAllStaticPages();

            Assert.AreEqual(0, staticPage.Count);
        }

        [Test]
        public void EFCanGetBlogPostById()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var blogsById = repo.GetBlogPostById(3);

            Assert.AreEqual("Tech Beers and Cheers", blogsById.Title);
            Assert.AreEqual("AJ", blogsById.User.FirstName);
            Assert.AreEqual("Rohde", blogsById.User.LastName);
        }

        [Test]
        public void EFCanGetPublishedPostsByTitle()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var publishedPosts = repo.GetPublishedPostsByTitle("Judy the Ruby Master");

            Assert.AreEqual(1, publishedPosts.Count);
            Assert.AreEqual("Lindsey", publishedPosts[0].User.FirstName);
            Assert.AreEqual("Parlow", publishedPosts[0].User.LastName);
            Assert.AreEqual(1, publishedPosts[0].BlogPostId);

            var publishedPosts2 = repo.GetPublishedPostsByTitle("the");

            Assert.AreEqual(3, publishedPosts2.Count);
            Assert.AreEqual("Lindsey", publishedPosts[0].User.FirstName);
            Assert.AreEqual("Parlow", publishedPosts[0].User.LastName);
            Assert.AreEqual(1, publishedPosts[0].BlogPostId);
        }

    }
}
