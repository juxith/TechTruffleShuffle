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
        List<BlogPost> GetAllRemovedPosts(bool isRemoved);
        List<BlogPost> GetAllPublishedPosts(int blogStatusId);
        List<BlogPost> GetAllFeaturedPosts(bool isFeatured);
<<<<<<< HEAD
        List<BlogPost> GetBlogPostById(int blogpostId);
=======
        BlogPost GetBlogPostById(int blogpostId);
>>>>>>> 973019289c5cfd795c45f7d898746cf2f2dbafd8
        List<BlogPost> GetAllPublishedPostsByHashtag(Hashtag hashtags);
        List<BlogPost> GetAllPublishedPostsByCategory(string category);
        List<BlogPost> GetAllPublishedPostsByDate(DateTime dateStart);
        List<BlogPost> GetAllPublishedPostsByAuthor(string authorName);
        BlogPost GetPublishedPostsByTitle(string title);
        List<BlogPost> GetAllPendingPosts(int blogStatusId);
        List<BlogPost> GetAllPendingPostsByOneAuthor(int blogStatusId, int authorId);
        List<BlogPost> GetAllDrafts(int blogStatusId);
        List<BlogPost> GetAllDraftsByOneAuthor(int blogStatusId, int authorId);
        List<BlogPost> GetAllStaticPages(bool isStatic);
        //void CreatePublishPostAdmin(BlogPost newPostToPublish);
        void CreatePendingPostAuthor(BlogPost newPostToPend);
        void EditBlogPost(int postId);
        void DeleteBlogPost(int postId);
    }
}
