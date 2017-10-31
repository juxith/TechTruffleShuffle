namespace TechTruffleShuffle.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TechTruffleShuffle.Data.TechTruffleShuffleEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TechTruffleShuffle.Data.TechTruffleShuffleEntities context)
        {
            // Load the user and role managers with our custom models
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleMgr = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));


            // have we loaded roles already?
            if (!roleMgr.RoleExists("admin"))
            {
                roleMgr.Create(new ApplicationRole() { Name = "admin" });
            }

            if (!roleMgr.RoleExists("author"))
            {
                roleMgr.Create(new ApplicationRole() { Name = "author" });  
            }

            var authorUser = new ApplicationUser()
            {
                UserName = "JudyThao",
                FirstName = "Judy",
                LastName = "Thao",
                Email = "juxith23@gmail.com",
                EmailConfirmed = true    
             };


            var user = new ApplicationUser()
            {
                UserName = "LindseyParlow",
                FirstName = "Lindsey",
                LastName = "Parlow",
                Email = "lindsey.parlow@gmail.com",
                EmailConfirmed = true
            };

            if(!userMgr.Users.Any(u => u.UserName == "JudyThao"))
            {
                userMgr.Create(authorUser, "testing123");

                context.SaveChanges();

                userMgr.AddToRole(authorUser.Id, "author");
            }

            if (!userMgr.Users.Any(u => u.UserName == "LindseyParlow"))
            {
                userMgr.Create(user, "testing123");

                context.SaveChanges();

                userMgr.AddToRole(user.Id, "admin");
            }       

            context.SaveChanges();
            return;

        }
    }
}
