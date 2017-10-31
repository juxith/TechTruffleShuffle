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

        [Route("blogs/isRemoved/{true}")]
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

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}

        //[Route("blog/{blogId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllPosts()
        //{

        //}
    }
}
