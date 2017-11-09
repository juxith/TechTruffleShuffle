using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTruffleShuffle.Models;

namespace TechTruffleShuffle.Data
{
    public class TruffleShuffleRepositoryEF : ITruffleShuffleRepository
    {
        public void CreateNewBlogPost(BlogPost newPost)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var thisUser = ctx.Users.SingleOrDefault(u => u.UserName == newPost.User.UserName);
                newPost.User = thisUser;
               
                ctx.BlogPost.Add(newPost);
                ctx.SaveChanges();
            }
        }

        public void DeleteBlogPost(int postId)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var deleteThis = ctx.BlogPost.SingleOrDefault(i => i.BlogPostId == postId);
                ctx.BlogPost.Remove(deleteThis);
                ctx.SaveChanges();
            };
        }

        public void EditBlogPost(BlogPost updatedBlogPost)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var editThis = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").SingleOrDefault(s => s.BlogPostId == updatedBlogPost.BlogPostId);
                editThis.Title = updatedBlogPost.Title;
                editThis.BlogContent = updatedBlogPost.BlogContent;
                editThis.EventDate = updatedBlogPost.EventDate;
                editThis.DateStart = updatedBlogPost.DateStart;
                editThis.DateEnd = updatedBlogPost.DateEnd;
                editThis.BlogCategoryId = updatedBlogPost.BlogCategoryId;
                editThis.BlogStatusId = updatedBlogPost.BlogStatusId;
                editThis.IsFeatured = updatedBlogPost.IsFeatured;
                editThis.IsStaticPage = updatedBlogPost.IsStaticPage;

                ctx.SaveChanges();
            }
        }

        public List<BlogPost> GetAllDrafts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getAllDrafts = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(s => s.BlogStatus.BlogStatusDescription == "Draft");
                return getAllDrafts.ToList();
            }
        }

        public List<BlogPost> GetAllDraftsByOneAuthor(string userName)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getDraftsByAuthor = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(s => s.BlogStatus.BlogStatusDescription == "Draft").Where(u => (u.User.FirstName + u.User.LastName).Contains(userName));
                return getDraftsByAuthor.ToList();
            }
        }


        public List<BlogPost> GetAllFeaturedPosts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var isFeaturedPost = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(i => i.IsFeatured == true).Where(p => p.BlogStatus.BlogStatusDescription == "Published");

                return isFeaturedPost.ToList();
            }
        }

        public List<BlogPost> GetAllPendingPosts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPendingPosts = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(p => p.BlogStatus.BlogStatusDescription == "Pending");

                return getPendingPosts.ToList();
            }
        }

        public List<BlogPost> GetAllPendingPostsByOneAuthor(string userName)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPendingByAuthor = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(b => b.BlogStatus.BlogStatusDescription == "Pending" && ((b.User.FirstName + " " + b.User.LastName).Contains(userName))).ToList();

                return getPendingByAuthor.ToList();
            }
        }

        public List<BlogPost> GetAllPosts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                return ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").ToList();
            }
        }

        public List<BlogPost> GetAllPublishedPosts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPublishedPosts = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(s => s.BlogStatus.BlogStatusDescription == "Published");
                return getPublishedPosts.ToList();
            }
        }

        public List<BlogPost> GetAllPublishedPostsByAuthor(string userName)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPublishedPostsByAuthor = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(b => b.BlogStatus.BlogStatusDescription == "Published" && ((b.User.FirstName + " " + b.User.LastName).Contains(userName))).ToList();

                return getPublishedPostsByAuthor.ToList();
            }
        }

        public List<BlogPost> GetAllPublishedPostsByCategory(int blogCategoryId)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPublishedPostsByCategory = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(c => c.BlogCategoryId == blogCategoryId).Where(s => s.BlogStatus.BlogStatusDescription == "Published");
                return getPublishedPostsByCategory.ToList();
            }
        }

        public List<BlogPost> GetAllPublishedPostsByDate(string dateStart)
        {
            DateTime thisDate = new DateTime();
            DateTime.TryParse(dateStart, out thisDate);

            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPublishedPostByDate = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(s => s.BlogStatus.BlogStatusDescription == "Published").Where(d => d.DateStart == thisDate);
                return getPublishedPostByDate.ToList();
            }
        }

        public List<BlogPost> GetAllPublishedPostsByHashtag(string hashtags)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getCollectionOfHashtags = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(n => n.BlogStatus.BlogStatusDescription == "Published");
                getCollectionOfHashtags = getCollectionOfHashtags.Where(p => p.Hashtags.Any(t => t.HashtagName.Contains(hashtags)));

                return getCollectionOfHashtags.ToList();
            }
        }

        public List<BlogPost> GetAllRemovedPosts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getRemovedPosts = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(i => i.BlogStatus.BlogStatusDescription == "Removed");
                return getRemovedPosts.ToList();
            }
        }

        public List<BlogPost> GetAllStaticPages()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getStaticPages = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(i => i.IsStaticPage == true);
                return getStaticPages.ToList();
            }
        }

        public BlogPost GetBlogPostById(int blogpostId)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getThisPost = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").SingleOrDefault(i => i.BlogPostId == blogpostId);
                return getThisPost;
            }
        }

        public List<BlogPost> GetPublishedPostsByTitle(string title)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPublishedByTitle = ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(b => b.BlogStatus.BlogStatusDescription == "Published").Where(t => t.Title.Contains(title));
                return getPublishedByTitle.ToList();
            }
        }

        public List<BlogStatus> GetAllBlogStatuses()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getAllBlogStatuses = ctx.BlogStatus;

                return getAllBlogStatuses.ToList();
            }
        }

        public List<BlogCategory> GetAllBlogCategories()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getAllBlogCategories = ctx.BlogCategory;

                return getAllBlogCategories.ToList();
            }
        }

        public List<Hashtag> GetAllHashTags()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getAllHashtags = ctx.Hashtag;

                return getAllHashtags.ToList();
            }
        }

        public BlogCategory GetBlogCategory(int id)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var blogCategory = ctx.BlogCategory.SingleOrDefault(c => c.BlogCategoryId == id);

                return blogCategory;
            }
        }

        public BlogStatus GetBlogStatus(string status)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var blogStatus = ctx.BlogStatus.SingleOrDefault(c => c.BlogStatusDescription == status);

                return blogStatus;
            }
        }
       
        public Hashtag GetHashtag(string hashtagName)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var hashtag = ctx.Hashtag.SingleOrDefault(c => c.HashtagName == hashtagName);

                return hashtag;
            }
        }

        public void AddHashTag(Hashtag newHash)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
               ctx.Hashtag.Add(newHash);
                ctx.SaveChanges();
            }
        }
   
        public List<BlogPost> GetAllBlogsNonRemovedBlogsByAuthor(string userName)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                return ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(b => (b.BlogStatus.BlogStatusDescription == "Pending" || b.BlogStatus.BlogStatusDescription == "Published" || b.BlogStatus.BlogStatusDescription == "Draft") && ((b.User.FirstName + " " + b.User.LastName).Contains(userName))).ToList();
            }
        }

        public List<BlogPost> GetAllBlogsRemovedBlogsByAuthor(string userName)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                return ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(b => b.BlogStatus.BlogStatusDescription == "Removed" && ((b.User.FirstName + " " + b.User.LastName).Contains(userName))).ToList();
            }
        }

        public List<BlogPost> GetAllNonDraftBlogsByAuthor(string userName)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                return ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(b => (b.BlogStatus.BlogStatusDescription == "Removed" || b.BlogStatus.BlogStatusDescription == "Published" || b.BlogStatus.BlogStatusDescription == "Draft") && ((b.User.FirstName + " " + b.User.LastName).Contains(userName))).ToList();
            }
        }

        public List<BlogPost> GetAllNonDraftBlogs()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                return ctx.BlogPost.Include("Hashtags").Include("BlogCategory").Include("BlogStatus").Include("User").Where(b => (b.BlogStatus.BlogStatusDescription != "Draft")).ToList();
            }
        }
    }
}
