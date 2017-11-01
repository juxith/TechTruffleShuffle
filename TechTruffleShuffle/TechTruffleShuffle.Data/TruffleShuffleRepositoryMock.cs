using System;
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
                    Title = "Testing to see if I'm removed",
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

                }
            };
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

        public void DeleteBlogPost(int postId)
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

            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Draft" && ((b.User.FirstName + " " + b.User.LastName).Contains(userName))).ToList();
        }

        public List<BlogPost> GetAllFeaturedPosts()
        {
            return _blogposts.Where(b => b.IsFeatured == true).ToList();
        }

        public List<BlogPost> GetAllPendingPosts()
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Pending").ToList();
        }

        public List<BlogPost> GetAllPendingPostsByOneAuthor(string userName)
        {
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Pending" && ((b.User.FirstName + " " + b.User.LastName).Contains(userName))).ToList();
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
            return _blogposts.Where(b => b.BlogStatus.BlogStatusDescription == "Published" && ((b.User.FirstName + " " + b.User.LastName).Contains(userName))).ToList();
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

        public List<BlogPost> GetAllStaticPages()
        {
            return _blogposts.Where(b => b.IsStaticPage == true).ToList();
        }

        public BlogPost GetBlogPostById(int blogpostId)
        {
            return _blogposts.SingleOrDefault(b => b.BlogPostId == blogpostId);
        }

        public List<BlogPost> GetPublishedPostsByTitle(string title)
        {
            return _blogposts.Where(b => b.Title.Contains(title)).ToList();
        }
    }
}
