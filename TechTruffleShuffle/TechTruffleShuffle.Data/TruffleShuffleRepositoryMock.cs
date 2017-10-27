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
                    BlogStatusId = 1,
                    BlogStatusDescription = "Published"
                },
            };

            _blogposts = new List<BlogPost>()
            {
                new BlogPost
                {
                    BlogPostId = 1,
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
                    Hashtags = _hashtags.Where(h => h.HashtagId == 1 || h.HashtagId == 3).ToList()
                }
            };
        }

        public void CreatePendingPostAuthor(BlogPost newPostToPend)
        {
            throw new NotImplementedException();
        }

        public void CreatePublishPostAdmin(BlogPost newPostToPublish)
        {
            throw new NotImplementedException();
        }

        public void DeleteDraft(int postId)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int postId)
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
            throw new NotImplementedException();
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

        public BlogPost GetPublishedPostsByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
