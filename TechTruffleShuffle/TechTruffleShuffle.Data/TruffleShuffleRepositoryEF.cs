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
        TechTruffleShuffleEntities ctx = new TechTruffleShuffleEntities();

        public void CreatePendingPostAuthor(BlogPost newPostToPend)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlogPost(int postId)
        {
            using (ctx)
            {

            };
        }

        public void EditBlogPost(int postId)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllDrafts(int blogStatusId)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllDraftsByOneAuthor(int blogStatusId, int authorId)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllFeaturedPosts(bool isFeatured)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPendingPosts(int blogStatusId)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPendingPostsByOneAuthor(int blogStatusId, int authorId)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPosts()
        {
            using (ctx)
            {
                return ctx.BlogPost.ToList();
            }
        }

        public List<BlogPost> GetAllPublishedPosts(int blogStatusId)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPublishedPostsByAuthor(string authorName)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPublishedPostsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPublishedPostsByDate(DateTime dateStart)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPublishedPostsByHashtag(Hashtag hashtags)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllRemovedPosts(bool isRemoved)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllStaticPages(bool isStatic)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetBlogPostById(int blogpostId)
        {
            throw new NotImplementedException();
        }

        public BlogPost GetPublishedPostsByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
