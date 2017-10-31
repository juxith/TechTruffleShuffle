using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TechTruffleShuffle.Data;
using TechTruffleShuffle.Models;

namespace TechTruffleShuffle.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RouteController : ApiController
    {
        [Route("blogs")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllPosts()
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllPosts();

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        //I feel like i need to do something here with modifying the method so that true is passed in somehow?
        [Route("blogs/isRemoved/true")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllRemovedPosts()
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllRemovedPosts();

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        //Same thing here with the published part
        [Route("blogs/blogStatus/published")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllPublishedPosts()
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllPublishedPosts();

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }
        
        //same here
        [Route("blogs/isFeatured/true")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllFeaturedPosts()
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllFeaturedPosts();

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        [Route("blog/{blogId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetBlogPostsById(int blogId)
        {
            BlogPost blogPosts = TechTruffleRepositoryFactory.Create().GetBlogPostById(blogId);

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        [Route("blogs/hashtag/{hashtag}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllPublishedPostsByHashtag(string hashtag)
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllPublishedPostsByHashtag(hashtag);

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }

        }

        [Route("blogs/category/{categoryid}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllPublishedPostsByCategory(int categoryId)
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllPublishedPostsByCategory(categoryId);

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        [Route("blogs/date/{postDate}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllPublishedPostsByDate(string postDate)
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllPublishedPostsByDate(postDate);

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        [Route("blogs/author/{userName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllPublishedPostsByAuthor(string userName)
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllPublishedPostsByAuthor(userName);

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        [Route("blogs/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetPublishedPostsByTitle(string title)
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetPublishedPostsByTitle(title);

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        //this one too
        [Route("blogs/blogStatus/pending")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllPendingPosts()
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllPendingPosts();

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        //don't even know....
        [Route("blogs/blogstatus/pending/author/{userName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllPendingPostsByOneAuthor(string userName)
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllPendingPostsByOneAuthor(userName);

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        //and this one too
        [Route("blogs/blogstatus/drafts")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllDrafts()
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllDrafts();

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        //idk
        [Route("blogs/blogstatus/pending/author/{userName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllDraftsByOneAuthor(string userName)
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllDraftsByOneAuthor(userName);

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        //same here
        [Route("blogs/isStatic/true")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllStaticPages()
        {
            List<BlogPost> blogPosts = TechTruffleRepositoryFactory.Create().GetAllStaticPages();

            if (blogPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(blogPosts);
            }
        }

        [Route("blog")]
        [AcceptVerbs("POST")]
        public IHttpActionResult CreateNewBlogPost(BlogPost newblogPost)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BlogPost blogPost = new BlogPost()
            {
                Title = newblogPost.Title,
                BlogContent = newblogPost.BlogContent,
                EventDate = newblogPost.EventDate,
                DateStart = newblogPost.DateStart,
                DateEnd = newblogPost.DateEnd,
                BlogCategoryId = newblogPost.BlogCategoryId,
                BlogStatusId = newblogPost.BlogStatusId,
                IsFeatured = newblogPost.IsFeatured,
                IsStaticPage = newblogPost.IsStaticPage,
                IsRemoved = newblogPost.IsRemoved,
                Hashtags = newblogPost.Hashtags,

                User = newblogPost.User,
                BlogCategory = newblogPost.BlogCategory,
                BlogStatus = newblogPost.BlogStatus
            };

            TechTruffleRepositoryFactory.Create().CreateNewBlogPost(newblogPost);
            return Created($"blog/{newblogPost.BlogPostId}", newblogPost);
        }

        [Route("blog/{blogId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult EditBlogPost(BlogPost newBlogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BlogPost blogPost = TechTruffleRepositoryFactory.Create().GetBlogPostById(newBlogPost.BlogPostId);

            if (blogPost == null)
            {
                return NotFound();
            }

            blogPost.Title = newBlogPost.Title;
            blogPost.BlogContent =newBlogPost.BlogContent;
            blogPost.EventDate =newBlogPost.EventDate;
            blogPost.DateStart =newBlogPost.DateStart;
            blogPost.DateEnd =newBlogPost.DateEnd;
            blogPost.BlogCategoryId =newBlogPost.BlogCategoryId;
            blogPost.BlogStatusId = newBlogPost.BlogStatusId;
            blogPost.IsFeatured = newBlogPost.IsFeatured;
            blogPost.IsStaticPage = newBlogPost.IsStaticPage;
            blogPost.IsRemoved = newBlogPost.IsRemoved;
            blogPost.Hashtags = newBlogPost.Hashtags;
            
            blogPost.User = newBlogPost.User;
            blogPost.BlogCategory = newBlogPost.BlogCategory;
            blogPost.BlogStatus = newBlogPost.BlogStatus;

            TechTruffleRepositoryFactory.Create().EditBlogPost(newBlogPost);
            return Ok(blogPost);
        }

        [Route("blog/{blogPostId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteBlogPost(int blogPostId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BlogPost blogPost = TechTruffleRepositoryFactory.Create().GetBlogPostById(blogPostId);

            if (blogPost == null)
            {
                return NotFound();
            }

            TechTruffleRepositoryFactory.Create().DeleteBlogPost(blogPostId);
            return Ok();
        }
    }
}
