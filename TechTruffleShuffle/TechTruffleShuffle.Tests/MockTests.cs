using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTruffleShuffle.Data;

namespace TechTruffleShuffle.Tests
{
    [TestFixture]
    public class MockTests
    {
        //[SetUp]
        //public void Init()
        //{
            
        //}

        [Test]
        public void CanLoadAllBlogPosts()
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

     
    }
}
