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
        [AllowAnonymous]
        public ActionResult Index()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var model = repo.GetAllFeaturedPosts();

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "admin,author")]
        public ActionResult Blogs()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var model = repo.GetAllPublishedPosts();

            return View(model);
        }

        [Authorize(Roles = "admin,author")]
        public ActionResult CreateBlog()
        {
            var viewModel = new BlogPostViewModel();
            viewModel.SetCategoryItems(TechTruffleRepositoryFactory.Create().GetAllBlogCategories());
            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "admin,author")]
        public ActionResult CreateBlog(BlogPostViewModel viewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                var repo = TechTruffleRepositoryFactory.Create();
                //handles users
                

                //handles the hashtags
                string[] hashTag = viewModel.StringHashtags.Split(' ');

                var hashTagRepo = repo.GetAllHashTags();

                foreach (var hash in hashTag)
                {
                    if (!hashTagRepo.Any(h => h.HashtagName == hash))
                    {
                        var newHash = new Hashtag();
                        newHash.HashtagName = hash;
                        repo.AddHashTag(newHash);
                    }
                    var hashToAdd = repo.GetAllHashTags().SingleOrDefault(h => h.HashtagName == hash);

                    viewModel.BlogPost.Hashtags = new List<Hashtag>();
                    viewModel.BlogPost.Hashtags.Add(hashToAdd);
                }

                //handles the blogcategory
                viewModel.BlogPost.BlogCategory = repo.GetBlogCategory(viewModel.BlogPost.BlogCategory.BlogCategoryId);

                //handles the Blog Status
                switch (submit)
                {
                    case "Save":
                        viewModel.BlogPost.BlogStatus = repo.GetBlogStatus("Draft");
                        break;
                    case "Post":
                        viewModel.BlogPost.BlogStatus = repo.GetBlogStatus("Pending");
                        break;
                    case "Publish":
                        viewModel.BlogPost.BlogStatus = repo.GetBlogStatus("Published");
                        break;
                    default:
                        break;
                }

                TechTruffleRepositoryFactory.Create().CreateNewBlogPost(viewModel.BlogPost);

                return RedirectToAction("Blogs");
            }
            else
            {
                return View(viewModel);
            }
        }

        [Authorize(Roles = "admin,author")]
        public ActionResult MyBlogs()
        {
            ViewBag.Message = "My Blogs";

            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Admin";

            return View();
        }
    }
}