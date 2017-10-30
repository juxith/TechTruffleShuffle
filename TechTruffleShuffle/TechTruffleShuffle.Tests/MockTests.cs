﻿using NUnit.Framework;
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
        public void CanGetAllDrafts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var drafts = repo.GetAllDrafts();

            Assert.AreEqual(2, drafts.Count);
            Assert.AreEqual(4, drafts[1].BlogPostId);
            Assert.AreEqual("Let's Get Together and Code", drafts[1].Title);
        }

        [Test]
        public void CanGetAllDraftsByOneAuthor()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var drafts = repo.GetAllDraftsByOneAuthor(3);

            Assert.AreEqual(1, drafts.Count);
            Assert.AreEqual(1, drafts[0].BlogPostId);
            Assert.AreEqual("Judy the Ruby Master", drafts[0].Title);
        }

        [Test]
        public void CanGetAllFeaturedPosts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var featuredPosts = repo.GetAllFeaturedPosts();

            Assert.AreEqual(1, featuredPosts.Count);
            Assert.AreEqual(2, featuredPosts[0].BlogPostId);
            Assert.AreEqual("Guide to Getting the Job", featuredPosts[0].Title);
        }

        [Test]
        public void CanGetAllPendingPosts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var pendingPosts = repo.GetAllPendingPosts();

            Assert.AreEqual(1, pendingPosts.Count);
            Assert.AreEqual(3, pendingPosts[0].BlogPostId);
            Assert.AreEqual("Tech Beers and Cheers", pendingPosts[0].Title);
        }

        [Test]
        public void CanGetAllPendingPostsByOneAuthor()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var pendingPosts = repo.GetAllPendingPostsByOneAuthor(1);

            Assert.AreEqual(1, pendingPosts.Count);
            Assert.AreEqual(3, pendingPosts[0].BlogPostId);
            Assert.AreEqual("Tech Beers and Cheers", pendingPosts[0].Title);

            var pendingPosts2 = repo.GetAllPendingPostsByOneAuthor(2);

            Assert.AreEqual(0, pendingPosts2.Count);
        }

        [Test]
        public void CanGetAllPublishedPosts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var publishedPosts = repo.GetAllPublishedPosts();

            Assert.AreEqual(1, publishedPosts.Count);
            Assert.AreEqual(2, publishedPosts[0].BlogPostId);
            Assert.AreEqual("Guide to Getting the Job", publishedPosts[0].Title);
        }

        //[Test]
        //public void CanGetAllPublishedPostsByAuthor()
        //{

        //}

        [Test]
        public void CanGetAllPublishedPostsByCategory()
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
        public void CanGetAllPublishedPostsByDate()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var publishedPostsbyDate = repo.GetAllPublishedPostsByDate("12/1/17");

            Assert.AreEqual(1, publishedPostsbyDate.Count);
            Assert.AreEqual(2, publishedPostsbyDate[0].BlogPostId);
            Assert.AreEqual("Guide to Getting the Job", publishedPostsbyDate[0].Title);

            var publishedPostsbyDate2 = repo.GetAllPublishedPostsByDate("10/31/17");

            Assert.AreEqual(0, publishedPostsbyDate2.Count);
        }

        //[Test]
        //public void CanGetAllPublishedPostsByHashtag()
        //{

        //}

        [Test]
        public void CanGetAllRemovedPosts()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var removedPosts = repo.GetAllRemovedPosts();

            Assert.AreEqual(1, removedPosts.Count);
            Assert.AreEqual(4, removedPosts[0].BlogPostId);
            Assert.AreEqual("Let's Get Together and Code", removedPosts[0].Title);
        }

        [Test]
        public void CanGetAllStaticPages()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var staticPage = repo.GetAllStaticPages();

            Assert.AreEqual(0, staticPage.Count);
        }

        //[Test]
        //public void CanGetBlogPostById()
        //{
        //    var repo = TechTruffleRepositoryFactory.Create();

        //    var blogs = repo.GetBlogPostById(2);

        //    Assert.AreEqual(1, )
        //}

        //[Test]
        //public void CanGetPublishedPostsByTitle()
        //{

        //}
    }
}
