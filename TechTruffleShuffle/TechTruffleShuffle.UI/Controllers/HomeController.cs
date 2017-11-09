using Microsoft.AspNet.Identity;
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
        [AllowAnonymous]
        public ActionResult CreateBlog(BlogPostViewModel viewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                var repo = TechTruffleRepositoryFactory.Create();

                var thisUserName =  User.Identity.GetUserName();
                viewModel.BlogPost.User = new ApplicationUser();
                viewModel.BlogPost.User.UserName = thisUserName;

                //handles user
                //using (var content = new TechTruffleShuffleEntities())
                //{
                //    var addThisUserToBlogPost = content.Users.SingleOrDefault(u => u.UserName == thisUserName);
                //    viewModel.BlogPost.User = addThisUserToBlogPost;
                //}
            
                //handles the hashtags
                string[] hashTag = viewModel.StringHashtags.Split(' ');

                var hashTagRepo = repo.GetAllHashTags();

                viewModel.BlogPost.Hashtags = new List<Hashtag>();

                foreach (var hash in hashTag)
                {
                    if (!hashTagRepo.Any(h => h.HashtagName == hash))
                    {
                        var newHash = new Hashtag();
                        newHash.HashtagName = hash;
                        repo.AddHashTag(newHash);
                    }

                    var hashToAdd = repo.GetAllHashTags().SingleOrDefault(h => h.HashtagName == hash);

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
                viewModel.SetCategoryItems(TechTruffleRepositoryFactory.Create().GetAllBlogCategories());
                return View(viewModel);
            }
        }

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