using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTruffleShuffle.Data;
using TechTruffleShuffle.Models;

namespace TechTruffleShuffle.UI.Models
{
    public class BlogPostViewModel
    {
        public BlogPost BlogPost { get; set; }
        public List<SelectListItem> BlogCategories { get; set; }
        public string StringHashtags { get; set; }

        public BlogPostViewModel()
        {
            BlogCategories = new List<SelectListItem>();
            BlogPost = new BlogPost();
        }

        public void SetCategoryItems(IEnumerable<BlogCategory> categories)
        {
            foreach (var category in categories)
            {
                BlogCategories.Add(new SelectListItem()
                {
                    Value = category.BlogCategoryId.ToString(),
                    Text = category.BlogCategoryName
                });
            }
        }
    }
}