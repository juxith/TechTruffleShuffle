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
        public void CreatePendingPostAuthor(BlogPost newPostToPend)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                ctx.BlogPost.Add(newPostToPend);
            }
        }

        public void DeleteBlogPost(int postId)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var deleteThis = ctx.BlogPost.SingleOrDefault(i => i.BlogPostId == postId);
                ctx.BlogPost.Remove(deleteThis);
            };
        }

        public void EditBlogPost(BlogPost updatedBlogPost)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var editThis = ctx.BlogPost.SingleOrDefault(s => s.BlogPostId == updatedBlogPost.BlogPostId);
                ctx.BlogPost.Remove(editThis);
                ctx.BlogPost.Add(updatedBlogPost);
            }
        }

        public List<BlogPost> GetAllDrafts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getAllDrafts = ctx.BlogPost.Where(s => s.BlogStatus.BlogStatusDescription == "Draft");
                return getAllDrafts.ToList();
            }
        }

        public List<BlogPost> GetAllDraftsByOneAuthor(int authorId)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getDraftsByAuthor = ctx.BlogPost.Where(s => s.BlogStatus.BlogStatusDescription == "Draft").Where(a => a.AuthorId == authorId);
                return getDraftsByAuthor.ToList();
            }
        }

        public List<BlogPost> GetAllFeaturedPosts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var isFeaturedPost = ctx.BlogPost.Where(i => i.IsFeatured == true);

                return isFeaturedPost.ToList();
            }
        }

        public List<BlogPost> GetAllPendingPosts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPendingPosts = ctx.BlogPost.Where(p => p.BlogStatus.BlogStatusDescription == "Pending");

                return getPendingPosts.ToList();
            }
        }

        public List<BlogPost> GetAllPendingPostsByOneAuthor(int authorId)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPendingByAuthor = ctx.BlogPost.Where(a => a.AuthorId == authorId).Where(s => s.BlogStatus.BlogStatusDescription == "Pending");

                return getPendingByAuthor.ToList();
            }
        }

        public List<BlogPost> GetAllPosts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                return ctx.BlogPost.ToList();
            }
        }

        public List<BlogPost> GetAllPublishedPosts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPublishedPosts = ctx.BlogPost.Where(s => s.BlogStatus.BlogStatusDescription == "Published");
                return getPublishedPosts.ToList();
            }
        }

        public List<BlogPost> GetAllPublishedPostsByAuthor(string authorName)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPublishedPostsByAuthor = ctx.BlogPost.Where(s => s.BlogStatusId == 3).Where(a => a.Author.FirstName.Contains(authorName) || a.Author.LastName.Contains(authorName));
                return getPublishedPostsByAuthor.ToList();
            }
        }

        public List<BlogPost> GetAllPublishedPostsByCategory(int blogCategoryId)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPublishedPostsByCategory = ctx.BlogPost.Where(c => c.BlogCategoryId == blogCategoryId).Where(s => s.BlogStatus.BlogStatusDescription == "Published");
                return getPublishedPostsByCategory.ToList();
            }
        }

        public List<BlogPost> GetAllPublishedPostsByDate(string dateStart)
        {
            DateTime thisDate = new DateTime();
            DateTime.TryParse(dateStart, out thisDate);

            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPublishedPostByDate = ctx.BlogPost.Where(s => s.BlogStatus.BlogStatusDescription == "Published").Where(d => d.DateStart == thisDate);
                return getPublishedPostByDate.ToList();
            }
        }

        public List<BlogPost> GetAllPublishedPostsByHashtag(string hashtags)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getCollectionOfHashtags = ctx.BlogPost.Where(n => n.BlogStatus.BlogStatusDescription == "Published");
                getCollectionOfHashtags = getCollectionOfHashtags.Where(p => p.Hashtags.Any(t => t.HashtagName.Contains(hashtags)));

                return getCollectionOfHashtags.ToList();
            }
        }

        public List<BlogPost> GetAllRemovedPosts()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getRemovedPosts = ctx.BlogPost.Where(i => i.IsRemoved == true);
                return getRemovedPosts.ToList();
            }
        }

        public List<BlogPost> GetAllStaticPages()
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getStaticPages = ctx.BlogPost.Where(i => i.IsStaticPage == true);
                return getStaticPages.ToList();
            }
        }

        public BlogPost GetBlogPostById(int blogpostId)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getThisPost = ctx.BlogPost.SingleOrDefault(i => i.BlogPostId == blogpostId);
                return getThisPost;
            }
        }

        public List<BlogPost> GetPublishedPostsByTitle(string title)
        {
            using (var ctx = new TechTruffleShuffleEntities())
            {
                var getPublishedByTitle = ctx.BlogPost.Where(b => b.BlogStatus.BlogStatusDescription == "Published").Where(t => t.Title.Contains(title));
                return getPublishedByTitle.ToList();
            }
        }
    }
}
