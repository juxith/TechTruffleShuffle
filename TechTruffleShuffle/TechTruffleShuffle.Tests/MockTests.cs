using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTruffleShuffle.Data;
using TechTruffleShuffle.Models;

namespace TechTruffleShuffle.Tests
{
    [TestFixture]
    public class MockTests
    {
        [SetUp]
        public void Setup()
        {
            TruffleShuffleRepositoryMock.LoadLists();
        }

        [Test]
        public void CanGetAllPosts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var blogPosts = repo.GetAllPosts();

            Assert.AreEqual(4, blogPosts.Count);
            Assert.AreEqual(1, blogPosts[2].AuthorId);
            Assert.AreEqual(2, blogPosts[2].BlogCategoryId);
            Assert.AreEqual(2, blogPosts[2].BlogStatusId);
            Assert.IsFalse(blogPosts[2].IsFeatured);
            Assert.IsFalse(blogPosts[2].IsFeatured);
            Assert.IsFalse(blogPosts[2].IsFeatured);
            Assert.AreEqual(2, blogPosts[2].Hashtags.Count);
        }

        [Test]
        public void CanCreateNewBlogPost()
        {
            var repo = TechTruffleRepositoryFactory.Create();
            
            BlogPost newBlogPost = new BlogPost();

            newBlogPost.Title = "Hey, This New Post!";
            newBlogPost.AuthorId = 2;
            newBlogPost.BlogContent = "Code and Talk and Code and Talk and Code and Talk. Success!";
            newBlogPost.EventDate = new DateTime(2017, 10, 30);
            newBlogPost.DateStart = new DateTime(2017, 11, 01);
            newBlogPost.DateEnd = new DateTime(12, 01, 01);
            newBlogPost.BlogCategoryId = 2;
            newBlogPost.BlogStatusId = 2;
            newBlogPost.IsFeatured = false;
            newBlogPost.IsStaticPage = false;
            newBlogPost.IsRemoved = false;
            newBlogPost.Hashtags = null;

            repo.CreateNewBlogPost(newBlogPost);

            Assert.AreEqual(5, newBlogPost.BlogPostId);

        }

        [Test]
        public void CanDeleteBlogPost()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            //add a blogpost first so I can try deleting it in the next step
            BlogPost newBlogPost = new BlogPost();

            newBlogPost.Title = "Hey, This New Post!";
            newBlogPost.AuthorId = 2;
            newBlogPost.BlogContent = "Code and Talk and Code and Talk and Code and Talk. Success!";
            newBlogPost.EventDate = new DateTime(2017, 10, 30);
            newBlogPost.DateStart = new DateTime(2017, 11, 01);
            newBlogPost.DateEnd = new DateTime(2017, 01, 01);
            newBlogPost.BlogCategoryId = 2;
            newBlogPost.BlogStatusId = 2;
            newBlogPost.IsFeatured = false;
            newBlogPost.IsStaticPage = false;
            newBlogPost.IsRemoved = false;
            newBlogPost.Hashtags = null;

            //check to make sure it added ok
            repo.CreateNewBlogPost(newBlogPost);
            var loaded = repo.GetBlogPostById(5);
            Assert.IsNotNull(loaded);

            //check to make sure that it deleted ok
            repo.DeleteBlogPost(5);
            loaded = repo.GetBlogPostById(5);
            Assert.IsNull(loaded);
        }

        [Test]
        public void CanEditBlogPost()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            //add a blogpost first so I can try editing it in next step
            BlogPost newBlogPost = new BlogPost();

            newBlogPost.Title = "Hey, This New Post!";
            newBlogPost.AuthorId = 2;
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
            newBlogPost.AuthorId = 3;
            newBlogPost.BlogContent = "Code, Code, Talk. Code, Code, Talk. Brilliant!";
            newBlogPost.EventDate = new DateTime(2017, 10, 30);
            newBlogPost.DateStart = new DateTime(2017, 11, 03);
            newBlogPost.DateEnd = new DateTime(17, 12, 03);
            newBlogPost.BlogCategoryId = 2;
            newBlogPost.BlogStatusId = 2;
            newBlogPost.IsFeatured = false;
            newBlogPost.IsStaticPage = false;
            newBlogPost.IsRemoved = false;
            newBlogPost.Hashtags = null;

            repo.EditBlogPost(newBlogPost);

            var editedBlogPost = repo.GetBlogPostById(5);

            Assert.AreEqual("Hey, This Post Was Updated!", editedBlogPost.Title);
            //Assert.AreEqual()
        }

        [Test]
        public void CanGetAllDrafts()
        {

        }

        [Test]
        public void CanGetAllDraftsByOneAuthor()
        {

        }

        [Test]
        public void CanGetAllFeaturedPosts()
        {

        }

        [Test]
        public void CanGetAllPendingPosts()
        {

        }

        [Test]
        public void CanGetAllPendingPostsByOneAuthor()
        {

        }

        [Test]
        public void CanGetAllPublishedPosts()
        {

        }

        [Test]
        public void CanGetAllPublishedPostsByAuthor()
        {

        }

        [Test]
        public void CanGetAllPublishedPostsByCategory()
        {

        }

        [Test]
        public void CanGetAllPublishedPostsByDate()
        {

        }

        [Test]
        public void CanGetAllPublishedPostsByHashtag()
        {

        }

        [Test]
        public void CanGetAllRemovedPosts()
        {

        }

        [Test]
        public void CanGetAllStaticPages()
        {

        }

        [Test]
        public void CanGetBlogPostById()
        {

        }

        [Test]
        public void CanGetPublishedPostsByTitle()
        {

        }
    }
}
