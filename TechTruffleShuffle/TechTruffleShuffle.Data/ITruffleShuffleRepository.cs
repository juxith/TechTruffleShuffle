﻿using System;
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
        List<StaticPage> GetAllStaticPages();
        //void CreatePublishPostAdmin(BlogPost newPostToPublish);
        void CreateNewBlogPost(BlogPost newPost);
        void EditBlogPost(BlogPost updatedBlogPost);
        void DeleteBlogPostDraft(int postId);

        List<BlogStatus> GetAllBlogStatuses();
        List<Hashtag> GetAllHashTags();
        List<BlogCategory> GetAllBlogCategories();

        StaticPage GetStaticPageByID(int ID);
        void CreateStaticPage(StaticPage model);
        BlogCategory GetBlogCategory(int id);
        BlogStatus GetBlogStatus(string status);
        Hashtag GetHashtag(string hashtagName);
        void AddHashTag(Hashtag newHash);

        //will need to modify this at some point so it isn't taking in a string but is
        //    figuring out who is logged in and using that.
        List<BlogPost> GetAllBlogsNonRemovedBlogsByAuthor(string authorName);
        List<BlogPost> GetAllBlogsRemovedBlogsByAuthor(string userName);
        List<BlogPost> GetAllNonDraftBlogsByAuthor(string userName);
        List<BlogPost> GetAllNonDraftBlogs();

    }
}
