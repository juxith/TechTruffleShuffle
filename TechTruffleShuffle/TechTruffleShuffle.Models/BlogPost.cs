using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTruffleShuffle.Data;

namespace TechTruffleShuffle.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        [Required(ErrorMessage = "Must enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Must enter blog content")]
        public string BlogContent { get; set; }
        public DateTime? EventDate { get; set; }

        [Required(ErrorMessage ="Must enter a valid date")]

        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        [Required (ErrorMessage ="Must select a blog category")]
        public int BlogCategoryId { get; set; }
        public int BlogStatusId { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsStaticPage { get; set; }
        public string UserId { get; set; }

        public ICollection<Hashtag> Hashtags { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual BlogCategory BlogCategory { get; set; }
        public virtual BlogStatus BlogStatus { get; set; }
    }
}
