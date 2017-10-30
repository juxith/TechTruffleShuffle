using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTruffleShuffle.Models;

namespace TechTruffleShuffle.Data
{
    public interface ITruffleShuffleRepository
    {
        List<BlogPost> GetAllPosts();
        List<BlogPost> GetAllRemovedPosts();
        List<BlogPost> GetAllPublishedPosts();
        List<BlogPost> GetAllFeaturedPosts();
        BlogPost GetBlogPostById(int blogpostId);
        List<BlogPost> GetAllPublishedPostsByHashtag(string hashtags);
        List<BlogPost> GetAllPublishedPostsByCategory(int blogCategoryId);
        List<BlogPost> GetAllPublishedPostsByDate(string dateStart);
        List<BlogPost> GetAllPublishedPostsByAuthor(string userName);
        List<BlogPost> GetPublishedPostsByTitle(string title);
        List<BlogPost> GetAllPendingPosts();
        List<BlogPost> GetAllPendingPostsByOneAuthor(string userName);
        List<BlogPost> GetAllDrafts();
        List<BlogPost> GetAllDraftsByOneAuthor(string userName);
        List<BlogPost> GetAllStaticPages();
        //void CreatePublishPostAdmin(BlogPost newPostToPublish);
        void CreateNewBlogPost(BlogPost newPost);
        void EditBlogPost(BlogPost updatedBlogPost);
        void DeleteBlogPost(int postId);
    }
}
