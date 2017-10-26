using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTruffleShuffle.Data
{
    public interface ITruffleShuffleRepository
    {
        List<Post> GetAllPosts();
        List<Post> GetAllRemovedPosts(bool isRemoved);
        List<Post> GetAllPublishedPosts(int blogStatusId);
        List<Post> GetAllFeaturedPosts(bool isFeatured);
        List<Post> GetAllPublishedPostsByHashtag(Hashtag hashtags);
        List<Post> GetAllPublishedPostsByCategory(string category);
        List<Post> GetAllPublishedPostsByDate(DateTime dateStart);
        List<Post> GetAllPublishedPostsByAuthor(string authorName);
        Post GetPublishedPostsByTitle(string title);
        List<Post> GetAllPendingPosts(int blogStatusId);
        List<Post> GetAllPendingPostsByOneAuthor(int blogStatusId, int authorId);
        List<Post> GetAllDrafts(int blogStatusId);
        List<Post> GetAllDraftsByOneAuthor(int blogStatusId, int authorId);
        List<Post> GetAllStaticPages(bool isStatic);
        void CreatePublishPostAdmin(Post newPostToPublish);
        void CreatePendingPostAuthor(Post newPostToPend);
        void DeletePost(int postId);
        void DeleteDraft(int postId);



    }
}
