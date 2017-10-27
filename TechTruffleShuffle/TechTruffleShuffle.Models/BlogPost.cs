using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTruffleShuffle.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string BlogContent { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int BlogCategoryId { get; set; }
        public int BlogStatusId { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsStaticPage { get; set; }
        public bool IsRemoved { get; set; }

        public ICollection<Hashtag> Hashtags { get; set; }

        public virtual Author Author { get; set; }
        public virtual BlogCategory BlogCategory { get; set; }
        public virtual BlogStatus BlogStatus { get; set; }
    }
}
