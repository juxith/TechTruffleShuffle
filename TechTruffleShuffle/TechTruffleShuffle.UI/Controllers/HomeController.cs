using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTruffleShuffle.Data;
using TechTruffleShuffle.Models;
using TechTruffleShuffle.UI.Models;

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
            var repo = TechTruffleRepositoryFactory.Create();

            var model = repo.GetAllPublishedPosts();

            return View(model);
        }

        public ActionResult CreateBlog()
        {
            var viewModel = new BlogPostViewModel();
            viewModel.SetCategoryItems(TechTruffleRepositoryFactory.Create().GetAllBlogCategories());
            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateBlog(BlogPostViewModel viewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                var model = new BlogPost();

                model.Title = viewModel.BlogPost.Title;
                model.EventDate = viewModel.BlogPost.EventDate;
                model.BlogContent = viewModel.BlogPost.BlogContent;
                model.IsFeatured = viewModel.BlogPost.IsFeatured;
                model.User = viewModel.BlogPost.User;

                string[] hashTag = viewModel.StringHashtags.Split(' ');

                var hashTagRepo = TechTruffleRepositoryFactory.Create().GetAllHashTags();

                foreach(var hash in hashTag)
                {
                    if(hashTagRepo.Any(h => h.HashtagName == hash))
                    {
                        var newHash = new Hashtag();
                        newHash.HashtagName = hash;
                        hashTagRepo.Add(newHash);
                        model.Hashtags.Add(newHash);
                    }
                    else
                    {
                        model.Hashtags.Add(hashTagRepo.SingleOrDefault(h => h.HashtagName == hash));
                    }
                }
                
                switch (submit)
                {
                    case "Save":
                        model.BlogStatus.BlogStatusDescription = "Draft";
                        break;
                    case "Post":
                        model.BlogStatus.BlogStatusDescription = "Pending";
                        break;
                    case "Publish":
                        model.BlogStatus.BlogStatusDescription = "Published";
                        break;
                    default:
                        break;
                }

                TechTruffleRepositoryFactory.Create().CreateNewBlogPost(model);

                return RedirectToAction("Home");
            }
            else
            {
                return View(viewModel);
            }
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