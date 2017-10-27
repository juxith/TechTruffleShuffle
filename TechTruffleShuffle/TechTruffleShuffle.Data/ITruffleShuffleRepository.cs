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
        List<BlogPost> GetAllPublishedPostsByAuthor(string authorName);
        List<BlogPost> GetPublishedPostsByTitle(string title);
        List<BlogPost> GetAllPendingPosts();
        List<BlogPost> GetAllPendingPostsByOneAuthor(int authorId);
        List<BlogPost> GetAllDrafts();
        List<BlogPost> GetAllDraftsByOneAuthor(int authorId);
        List<BlogPost> GetAllStaticPages();
        //void CreatePublishPostAdmin(BlogPost newPostToPublish);
        void CreatePendingPostAuthor(BlogPost newPostToPend);
        void EditBlogPost(BlogPost updatedBlogPost);
        void DeleteBlogPost(int postId);
    }
}
