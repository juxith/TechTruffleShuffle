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
        private static List<Author> _authors;
        private static List<BlogCategory> _blogcategories;
        private static List<Hashtag> _hashtags;
        private static List<BlogStatus> _blogstatuses;
        private static List<BlogPost> _blogposts;

        static TruffleShuffleRepositoryMock()
        {
            _authors = new List<Author>()
            {
                new Author
                {
                    AuthorId = 1,
                    FirstName = "Judy",
                    LastName = "Thao"
                },
                new Author
                {
                    AuthorId = 2,
                    FirstName = "AJ",
                    LastName = "Rohde"
                },
                new Author
                {
                    AuthorId = 3,
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
                    HashtagName = "#PizzaAndCoding"
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
            };

            _blogposts = new List<BlogPost>()
            {
                new BlogPost
                {
                    BlogPostId = 1,
                    Title = "Judy the Ruby Master",
                    AuthorId = 3,
                    BlogContent = "Judy took us on a tour of her newest Ruby project, teaching us how to get down the yellow brick road to success.",
                    EventDate = new DateTime(2017, 11, 31),
                    DateStart = new DateTime(2017, 12, 01),
                    DateEnd = new DateTime(2018, 01, 01),
                    BlogCategoryId = 1,
                    BlogStatusId = 1,
                    IsFeatured = false,
                    IsStaticPage = false,
                    IsRemoved = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 1 || h.HashtagId == 5).ToList()
                },
                new BlogPost
                {
                    BlogPostId = 2,
                    Title = "Guide to Getting the Job",
                    AuthorId = 2,
                    BlogContent = "Smile... But only if you've brushed your teeth.",
                    EventDate = new DateTime(2017, 11, 31),
                    DateStart = new DateTime(2017, 12, 01),
                    DateEnd = new DateTime(2018, 01, 01),
                    BlogCategoryId = 3,
                    BlogStatusId = 3,
                    IsFeatured = true,
                    IsStaticPage = false,
                    IsRemoved = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 4 || h.HashtagId == 2).ToList()
                },
                new BlogPost
                {
                    BlogPostId = 3,
                    Title = "Tech Beers and Cheers",
                    AuthorId = 1,
                    BlogContent = "Want to meet other people in the tech industry? Like Beer? This is the perfect meetup for you!",
                    EventDate = new DateTime(2017, 10, 31),
                    DateStart = new DateTime(2017, 11, 01),
                    DateEnd = new DateTime(2018, 11, 15),
                    BlogCategoryId = 2,
                    BlogStatusId = 2,
                    IsFeatured = false,
                    IsStaticPage = false,
                    IsRemoved = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 1 || h.HashtagId == 3).ToList()
                },
                new BlogPost
                {
                    BlogPostId = 4,
                    Title = "Judy the Ruby Master",
                    AuthorId = 1,
                    BlogContent = "Judy took us on a tour of her newest Ruby app, teaching us how to get down the yellow brick road to success.",
                    EventDate = new DateTime(2017, 11, 31),
                    DateStart = new DateTime(2017, 12, 01),
                    DateEnd = new DateTime(2018, 01, 01),
                    BlogCategoryId = 1,
                    BlogStatusId = 1,
                    IsFeatured = false,
                    IsStaticPage = false,
                    IsRemoved = false,
                    Hashtags = _hashtags.Where(h => h.HashtagId == 5 || h.HashtagId == 6).ToList()
                }
            };
        }

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
