using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTruffleShuffle.Models
{
    public class BlogHashtag
    {
        public int BlogId { get; set; }
        public int HashtagId { get; set; }

        public virtual BlogPost Blog { get; set; }
        public virtual Hashtag Hashtag { get; set; }
    }
}
