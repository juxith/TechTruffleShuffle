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
                 UserName = "authorUser"
             };

             var user = new ApplicationUser()
             {
                 UserName = "adminUser"
             };

            if(!userMgr.Users.Any(u => u.UserName == "authorUser"))
            {
                userMgr.Create(authorUser, "testing123");

                context.SaveChanges();

                userMgr.AddToRole(authorUser.Id, "author");
            }

            if (!userMgr.Users.Any(u => u.UserName == "adminUser"))
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
