﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTruffleShuffle.Models;

namespace TechTruffleShuffle.Data
{
    public class TruffleShuffleRepositoryMock : ITruffleShuffleRepository
    {
        private static List<ApplicationUser> _appUsers;
        private static List<BlogCategory> _blogcategories;
        private static List<Hashtag> _hashtags;
        private static List<BlogStatus> _blogstatuses;
        private static List<BlogPost> _blogposts;

        static TruffleShuffleRepositoryMock()
        {
            LoadLists();
        }

        public static void LoadLists()
        {
            _appUsers = new List<ApplicationUser>()

            {
                new ApplicationUser
                {
                    Id = "user1",
                    FirstName = "Judy",
                    LastName = "Thao"
                },
                new ApplicationUser
                {
                    Id = "user2",
                    FirstName = "AJ",
                    LastName = "Rohde"
                },
                new ApplicationUser
                {
                    Id = "user3",
                    FirstName = "Lindsey",
                    LastName = "Parlow"
                },
            };

            _blogcategories = new List<BlogCategory>()
            {
                new BlogCategory
                {
                    BlogCategoryId = 1,
                    BlogCategoryName = "Technical"
                },
                new BlogCategory
                {
                    BlogCategoryId = 2,
                    BlogCategoryName = "Social"
                },
                new BlogCategory
                {
                    BlogCategoryId = 3,
                    BlogCategoryName = "Networking"
                },
                new BlogCategory
                {
                    BlogCategoryId = 4,
                    BlogCategoryName = "Other"
                }
            };

            _hashtags = new List<Hashtag>()
            {
                new Hashtag
                {
                    HashtagId = 1,
                    HashtagName = "#Ruby"
                },
                new Hashtag
                {
                    HashtagId = 2,
                    HashtagName = "#Learning"
                },
                new Hashtag
                {
                    HashtagId = 3,
                    HashtagName = "#OOP"
                },
                new Hashtag
                {
                    HashtagId = 4,
                    HashtagName = "#InItToWinIt"
                },
                new Hashtag
                {
                    HashtagId = 5,
                    HashtagName = "#CodeMaster"
                },
                new Hashtag
                {
                    HashtagId = 6,
                    HashtagName = "#BeerAndCoding"
                },
            };

            _blogstatuses = new List<BlogStatus>()
            {
                new BlogStatus
                {
                    BlogStatusId = 1,
                    BlogStatusDescription = "Draft"
                },
                new BlogStatus
                {
                    BlogStatusId = 2,
                    BlogStatusDescription = "Pending"
                },
                new BlogStatus
                {
                    BlogStatusId = 3,
                    BlogStatusDescription = "Published"
                },
                    new BlogStatus
                {
                    BlogStatusId = 4,
                    BlogStatusDescription = "Removed"
                }
            };

            _blogposts = new List<BlogPost>()
            {
                new BlogPost
                {
                    BlogPostId = 1,
                    Title = "Judy the Ruby Master",
                    BlogContent = "Judy took us on a tour of her newest Ruby project, teaching us how to get down the yellow brick road to success.",
                    EventDate = new DateTime(2017, 11, 30),
                    DateStart = new DateTime(2017, 12, 01),
                    DateEnd = new DateTime(2018, 01, 01),
                    BlogCategoryId = 1,
                    BlogStatusId = 1,
                    IsFeatured = false,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 1 || h.HashtagId == 5).ToList(),

                    User = _appUsers[2],
                    BlogCategory = _blogcategories[0],
                    BlogStatus = _blogstatuses[0]
                },
                new BlogPost
                {
                    BlogPostId = 2,
                    Title = "Guide to Getting the Job",
                    BlogContent = "Smile... But only if you've brushed your teeth.",
                    EventDate = new DateTime(2017, 11, 30),
                    DateStart = new DateTime(2017, 12, 01),
                    DateEnd = new DateTime(2018, 01, 01),
                    BlogCategoryId = 3,
                    BlogStatusId = 3,
                    IsFeatured = true,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 4 || h.HashtagId == 2).ToList(),

                    User = _appUsers[0],
                    BlogCategory = _blogcategories[2],
                    BlogStatus = _blogstatuses[2]
                },
                new BlogPost
                {
                    BlogPostId = 3,
                    Title = "Tech Beers and Cheers",
                    BlogContent = "Want to meet other people in the tech industry? Like Beer? This is the perfect meetup for you!",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 11, 01),
                    DateEnd = new DateTime(2018, 11, 15),
                    BlogCategoryId = 2,
                    BlogStatusId = 2,
                    IsFeatured = false,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 1 || h.HashtagId == 3).ToList(),

                    User = _appUsers[1],
                    BlogCategory = _blogcategories[1],
                    BlogStatus = _blogstatuses[1]
                },
                new BlogPost
                {
                    BlogPostId = 4,
                    Title = "Let's Get Together and Code",
                    BlogContent = "People got together. People did some coding.",
                    EventDate = new DateTime(2017, 8, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 1,
                    BlogStatusId = 1,
                    IsFeatured = false,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 5 || h.HashtagId == 6).ToList(),

                    User = _appUsers[1],
                    BlogCategory = _blogcategories[0],
                    BlogStatus = _blogstatuses[0]

                },
                new BlogPost
                {
                    BlogPostId = 5,
                    Title = "Anoother blog to test",
                    BlogContent = "Lindsey, Aj and Judy quest to complete their final group project.",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 1,
                    BlogStatusId = 4,
                    IsFeatured = false,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 5 || h.HashtagId == 6).ToList(),

                    User = _appUsers[1],
                    BlogCategory = _blogcategories[0],
                    BlogStatus = _blogstatuses[3]
                },
                new BlogPost
                {
                    BlogPostId = 6,
                    Title = "We are Getting Close to the End!",
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 3,
                    BlogStatusId = 1,
                    IsFeatured = false,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 4 || h.HashtagId == 2).ToList(),

                    User = _appUsers[2],
                    BlogCategory = _blogcategories[2],
                    BlogStatus = _blogstatuses[0]
                },
                new BlogPost
                {
                    BlogPostId = 7,
                    Title = "Let's Bust a Move",
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 2,
                    BlogStatusId = 2,
                    IsFeatured = false,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 6).ToList(),

                    User = _appUsers[2],
                    BlogCategory = _blogcategories[1],
                    BlogStatus = _blogstatuses[1]
                },
                new BlogPost
                {
                    BlogPostId = 8,
                    Title = "Tech it with your best shot",
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 1,
                    BlogStatusId = 3,
                    IsFeatured = true,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 3 || h.HashtagId == 5).ToList(),

                    User = _appUsers[1],
                    BlogCategory = _blogcategories[0],
                    BlogStatus = _blogstatuses[2]
                },
                new BlogPost
                {
                    BlogPostId = 9,
                    Title = "C# is Awesome. We are Awesome.",
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 1,
                    BlogStatusId = 4,
                    IsFeatured = true,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 5).ToList(),

                    User = _appUsers[2],
                    BlogCategory = _blogcategories[0],
                    BlogStatus = _blogstatuses[3]
                },
                new BlogPost
                {
                    BlogPostId = 10,
                    Title = "Just keep swimming, just keep swimming",
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 2,
                    BlogStatusId = 1,
                    IsFeatured = false,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 2 || h.HashtagId == 6).ToList(),

                    User = _appUsers[1],
                    BlogCategory = _blogcategories[1],
                    BlogStatus = _blogstatuses[0]
                },
                new BlogPost
                {
                    BlogPostId = 11,
                    Title = "Networking Tips for Newbies",
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 3,
                    BlogStatusId = 4,
                    IsFeatured = true,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 4 || h.HashtagId == 2).ToList(),

                    User = _appUsers[1],
                    BlogCategory = _blogcategories[2],
                    BlogStatus = _blogstatuses[3]
                },
                new BlogPost
                {
                    BlogPostId = 12,
                    Title = "Get all the jobs!!!",
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 3,
                    BlogStatusId = 2,
                    IsFeatured = false,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 4).ToList(),

                    User = _appUsers[2],
                    BlogCategory = _blogcategories[2],
                    BlogStatus = _blogstatuses[1]
                },
                new BlogPost
                {
                    BlogPostId = 13,
                    Title = "Learn a new language with Lindsey",
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 1,
                    BlogStatusId = 3,
                    IsFeatured = true,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 2 || h.HashtagId == 3 || h.HashtagId == 5).ToList(),

                    User = _appUsers[2],
                    BlogCategory = _blogcategories[0],
                    BlogStatus = _blogstatuses[2]
                },
                new BlogPost
                {
                    BlogPostId = 14,
                    Title = "Angular. The Next Frontier",
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. .",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 1,
                    BlogStatusId = 3,
                    IsFeatured = false,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 5).ToList(),

                    User = _appUsers[1],
                    BlogCategory = _blogcategories[0],
                    BlogStatus = _blogstatuses[2]
                },
                new BlogPost
                {
                    BlogPostId = 15,
                    Title = "Social Time!",
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategoryId = 2,
                    BlogStatusId = 3,
                    IsFeatured = false,
                    IsStaticPage = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 6).ToList(),

                    User = _appUsers[2],
                    BlogCategory = _blogcategories[1],
                    BlogStatus = _blogstatuses[2]
                }
            };
        }

        public void CreateStaticPage(StaticPage staticPage)
        {
            throw new NotImplementedException();
            //using (var ctx = new TechTruffleShuffleEntities())
            //{
            //    ctx.StaticPage.Add(staticPage);
            //    ctx.SaveChanges();
            //}
        }

        public StaticPage GetStaticPageByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void CreateNewBlogPost(BlogPost newPost)
        {
            if(_blogposts.Any())
            {
                newPost.BlogPostId = _blogposts.Max(b => b.BlogPostId) + 1;
            }
            else
            {
                newPost.BlogPostId = 1;
            }

            _blogposts.Add(newPost);
        }

        public void DeleteBlogPostDraft(int postId)
        {
            _blogposts.RemoveAll(b => b.BlogPostId == postId);
        }

        public void EditBlogPost(BlogPost updatedBlogPost)
        {
            _blogposts.RemoveAll(b => b.BlogPostId == updatedBlogPost.BlogPostId);
            _blogposts.Add(updatedBlogPost);
        }

        public List<BlogPost> GetAllDrafts()
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Draft").ToList();
        }

        public List<BlogPost> GetAllDraftsByOneAuthor(string userName)
        {

            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Draft" && (((b.User.FirstName + " " + b.User.LastName).Contains(userName)) || ((b.User.FirstName + b.User.LastName).Contains(userName)))).ToList();
        }

        public List<BlogPost> GetAllFeaturedPosts()
        {
            return _blogposts.Where(b => b.IsFeatured == true && b.BlogStatus.BlogStatusDescription == "Published").ToList();
        }

        public List<BlogPost> GetAllPendingPosts()
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Pending").ToList();
        }

        public List<BlogPost> GetAllPendingPostsByOneAuthor(string userName)
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Pending" && (((b.User.FirstName + " " + b.User.LastName).Contains(userName)) || ((b.User.FirstName + b.User.LastName).Contains(userName)))).ToList();
        }

        public List<BlogPost> GetAllPosts()
        {
            return _blogposts;
        }

        public List<BlogPost> GetAllPublishedPosts()
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Published").ToList();
        }
        
        public List<BlogPost> GetAllPublishedPostsByAuthor(string userName)
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Published" && (((b.User.FirstName + " " + b.User.LastName).Contains(userName)) || ((b.User.FirstName + b.User.LastName).Contains(userName)))).ToList();
        }

        public List<BlogPost> GetAllPublishedPostsByCategory(int blogCategoryId)
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Published" && b.BlogCategoryId == blogCategoryId).ToList();
        }

        public List<BlogPost> GetAllPublishedPostsByDate(string dateStart)
        {
            var thisDate = new DateTime();
            DateTime.TryParse(dateStart, out thisDate);

            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Published" && b.DateStart == thisDate).ToList();
        }

        public List<BlogPost> GetAllPublishedPostsByHashtag(string hashtags)
        {
            var publishedBlogposts = _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Published");
            publishedBlogposts = publishedBlogposts.Where(p => p.Hashtags.Any(h => h.HashtagName.Contains(hashtags)));

            return publishedBlogposts.ToList();
        }

        public List<BlogPost> GetAllRemovedPosts()
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Removed").ToList();
        }

        public List<StaticPage> GetAllStaticPages()
        {
            throw new NotImplementedException();
        }

        public BlogPost GetBlogPostById(int blogpostId)
        {
            return _blogposts.SingleOrDefault(b => b.BlogPostId == blogpostId);
        }

        public List<BlogPost> GetPublishedPostsByTitle(string title)
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Published" && b.Title.Contains(title)).ToList();
        }

        public List<BlogStatus> GetAllBlogStatuses()
        {
            return _blogstatuses.ToList();
        }

        public List<BlogCategory> GetAllBlogCategories()
        {
            return _blogcategories.ToList();
        }

        public List<Hashtag> GetAllHashTags()
        {
            return _hashtags.ToList();
        }

        public BlogCategory GetBlogCategory(int id)
        {
            var blogCategory = _blogcategories.SingleOrDefault(i => i.BlogCategoryId == id);
            return blogCategory;
        }

        public BlogStatus GetBlogStatus(string status)
        {
            var blogStatus = _blogstatuses.SingleOrDefault(i => i.BlogStatusDescription == status);
            return blogStatus;
        }

        public Hashtag GetHashtag(string hashtagName)
        {
            var hashtag = _hashtags.SingleOrDefault(i => i.HashtagName == hashtagName);
            return hashtag;
        }

        public void AddHashTag(Hashtag newHash)
        {
            var id = _hashtags.Max(m => m.HashtagId);
            newHash.HashtagId = id + 1;
            _hashtags.Add(newHash);
        }

        public List<BlogPost> GetAllBlogsNonRemovedBlogsByAuthor(string userName)
        {
            return _blogposts.Where(b => (b.BlogStatus.BlogStatusDescription == "Pending" || b.BlogStatus.BlogStatusDescription == "Published" || b.BlogStatus.BlogStatusDescription == "Draft") && ((b.User.FirstName + " " + b.User.LastName).Contains(userName)) || ((b.User.FirstName + b.User.LastName).Contains(userName))).ToList();
        }

        public List<BlogPost> GetAllBlogsRemovedBlogsByAuthor(string userName)
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Removed" && (((b.User.FirstName + " " + b.User.LastName).Contains(userName)) || ((b.User.FirstName + b.User.LastName).Contains(userName)))).ToList();
        }

        public List<BlogPost> GetAllNonDraftBlogsByAuthor(string userName)
        {
            return _blogposts.Where(b => (b.BlogStatus.BlogStatusDescription == "Removed" || b.BlogStatus.BlogStatusDescription == "Published" || b.BlogStatus.BlogStatusDescription == "Pending") && (((b.User.FirstName + " " + b.User.LastName).Contains(userName)) || ((b.User.FirstName + b.User.LastName).Contains(userName)))).ToList();
        }

        public List<BlogPost> GetAllNonDraftBlogs()
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Removed" || b.BlogStatus.BlogStatusDescription == "Published" || b.BlogStatus.BlogStatusDescription == "Pending").ToList();
        }
    }
}
    
