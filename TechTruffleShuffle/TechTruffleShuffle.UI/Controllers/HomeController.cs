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

        //[Authorize(Roles = "admin,author")]
        public ActionResult Blogs()
        {
            var repo = TechTruffleRepositoryFactory.Create();

            var model = repo.GetAllPublishedPosts();

            return View(model);
        }
        public ActionResult CreateStaticPage()
        {
            var viewModel = new BlogPostViewModel();
            viewModel.SetCategoryItems(TechTruffleRepositoryFactory.Create().GetAllBlogCategories());
            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "admin,author")]
        public ActionResult CreateStaticPage(BlogPostViewModel viewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                var repo = TechTruffleRepositoryFactory.Create();
                //handles users

                var authUserName = User.Identity.GetUserName();
                viewModel.BlogPost.User = new ApplicationUser();
                viewModel.BlogPost.User.UserName = authUserName;

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
                var authUserName = User.Identity.GetUserName();
                viewModel.BlogPost.User = new ApplicationUser();
                viewModel.BlogPost.User.UserName = authUserName;

                //handles the hashtags
                string[] hashTag = viewModel.StringHashtags.Split(' ');

                var hashTagEntity = repo.GetAllHashTags();

                viewModel.BlogPost.Hashtags = new List<Hashtag>();

                foreach (var hash in hashTag)
                {
                    var ht = hashTagEntity.FirstOrDefault( i =>i.HashtagName == hash);

                    if (ht == null)
                    {
                        var newHash = new Hashtag();
                        newHash.HashtagName = hash;
                        viewModel.BlogPost.Hashtags.Add(newHash);
                    }
                    else
                    {
                        viewModel.BlogPost.Hashtags.Add(ht);
                    }
                }

                //handles the blogcategory
                viewModel.BlogPost.BlogCategory = repo.GetBlogCategory(viewModel.BlogPost.BlogCategory.BlogCategoryId);

                //handles date

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

                repo.CreateNewBlogPost(viewModel.BlogPost);

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

        public ActionResult Edit(int id)
        {
            var thisBlogPost = TechTruffleRepositoryFactory.Create().GetBlogPostById(id);
            var convertHashToString = string.Empty;

            foreach (var hash in thisBlogPost.Hashtags)
            {
                convertHashToString += hash.HashtagName.ToString() + " ";
            }
            var viewModel = new BlogPostViewModel();

            viewModel.StringHashtags = convertHashToString;
            viewModel.BlogPost = thisBlogPost;
            viewModel.SetCategoryItems(TechTruffleRepositoryFactory.Create().GetAllBlogCategories());

            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "admin,author")]
        public ActionResult Edit(BlogPostViewModel viewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                var repo = TechTruffleRepositoryFactory.Create();

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

                    if (viewModel.BlogPost.Hashtags == null)
                    {
                        viewModel.BlogPost.Hashtags = new List<Hashtag>();
                        viewModel.BlogPost.Hashtags.Add(hashToAdd);
                    }
                    else
                    {
                        viewModel.BlogPost.Hashtags.Add(hashToAdd);
                    }
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

                repo.EditBlogPost(viewModel.BlogPost);

                return RedirectToAction("Blogs");
            }
            else
            {
                return View(viewModel);
            }
        }
    }
}