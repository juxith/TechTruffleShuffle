using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using TechTruffleShuffle.Models;

namespace TechTruffleShuffle.Data
{
    public class TechTruffleShuffleEntities : DbContext
    {
        public TechTruffleShuffleEntities() : base("TechTruffleShuffle")
        {

        }
        
        public DbSet<Author> Author { get; set; }
        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<BlogHashtag> BlogHashTag { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<BlogStatus> BlogStatus { get; set; }
        public DbSet<Hashtag> Hashtag { get; set; }
    }
}
