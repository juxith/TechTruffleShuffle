using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using TechTruffleShuffle.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TechTruffleShuffle.Data
{
    public class TechTruffleShuffleEntities : IdentityDbContext<ApplicationUser>
    {
        public static TechTruffleShuffleEntities Create()
        {
            return new TechTruffleShuffleEntities();
        }

        public TechTruffleShuffleEntities() : base("TechTruffleShuffle")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        
        
        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<BlogStatus> BlogStatus { get; set; }

        public DbSet<Hashtag> Hashtag { get; set; }
    }
}
