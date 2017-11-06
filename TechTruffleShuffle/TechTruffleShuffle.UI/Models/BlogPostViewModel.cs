using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechTruffleShuffle.Data;
using TechTruffleShuffle.Models;

namespace TechTruffleShuffle.UI.Models
{
    public class BlogPostViewModel
    {
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
        public string Hashtags { get; set; }
        public bool IsFeatured { get; set; }
        public string BlogContent { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public BlogStatus BlogStatus {get; set;}
        public ApplicationUser User { get; set; }
    }
}