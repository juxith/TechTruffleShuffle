using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTruffleShuffle.Data;

namespace TechTruffleShuffle.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var model = repo.GetAllFeaturedPosts();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Blogs()
        {
            ViewBag.Message = "Our blog page.";

            return View();
        }

        public ActionResult CreateBlog()
        {
            ViewBag.Message = "Create Page";

            return View();
        }

        public ActionResult MyBlogs()
        {
            ViewBag.Message = "My Blogs";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Admin";

            return View();
        }
    }
}