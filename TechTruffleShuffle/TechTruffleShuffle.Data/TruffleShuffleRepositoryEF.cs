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
            throw new NotImplementedException();
        }

        public void DeleteBlogPost(int postId)
        {
            throw new NotImplementedException();
        }

        public void EditBlogPost(BlogPost updatedBlogPost)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllDrafts()
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllDraftsByOneAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllFeaturedPosts()
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPendingPosts()
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPendingPostsByOneAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPublishedPosts()
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPublishedPostsByAuthor(string authorName)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPublishedPostsByCategory(int blogCategoryId)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPublishedPostsByDate(string dateStart)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllPublishedPostsByHashtag(string hashtags)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllRemovedPosts()
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllStaticPages()
        {
            throw new NotImplementedException();
        }

        public BlogPost GetBlogPostById(int blogpostId)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetPublishedPostsByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
