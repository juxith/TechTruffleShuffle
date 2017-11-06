namespace TechTruffleShuffle.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TechTruffleShuffle.Models;

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

            //if (!System.Diagnostics.Debugger.IsAttached)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            // #this is where the hashtags are seeded. 
            if (!context.Hashtag.Any(t => t.HashtagName == "#VirtualReality"))
            {
                Hashtag toAdd = new Hashtag
                {
                    HashtagName = "#VirtualReality"
                };

                context.Hashtag.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.Hashtag.Any(t => t.HashtagName == "#MobileDevelopment"))
            {
                Hashtag toAdd = new Hashtag
                {
                    HashtagName = "#MobileDevelopment"
                };

                context.Hashtag.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.Hashtag.Any(t => t.HashtagName == "#Angular"))
            {
                Hashtag toAdd = new Hashtag
                {
                    HashtagName = "#Angular"
                };

                context.Hashtag.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.Hashtag.Any(t => t.HashtagName == "#Hack"))
            {
                Hashtag toAdd = new Hashtag
                {
                    HashtagName = "#Hack"
                };

                context.Hashtag.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.Hashtag.Any(t => t.HashtagName == "#TallBoys"))
            {
                Hashtag toAdd = new Hashtag
                {
                    HashtagName = "#TallBoys"
                };

                context.Hashtag.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.Hashtag.Any(t => t.HashtagName == "#SoftSkills"))
            {
                Hashtag toAdd = new Hashtag
                {
                    HashtagName = "#SoftSkills"
                };

                context.Hashtag.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.Hashtag.Any(t => t.HashtagName == "#HashBrowns"))
            {
                Hashtag toAdd = new Hashtag
                {
                    HashtagName = "#HashBrowns"
                };

                context.Hashtag.Add(toAdd);
                context.SaveChanges();
            }

            // #this is where BlogCategories 
            if (!context.BlogCategory.Any(t => t.BlogCategoryName == "Technical"))
            {
                BlogCategory toAdd = new BlogCategory
                {
                    BlogCategoryName = "Technical"
                };

                context.BlogCategory.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.BlogCategory.Any(t => t.BlogCategoryName == "Social"))
            {
                BlogCategory toAdd = new BlogCategory
                {
                    BlogCategoryName = "Social"
                };

                context.BlogCategory.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.BlogCategory.Any(t => t.BlogCategoryName == "Networking"))
            {
                BlogCategory toAdd = new BlogCategory
                {
                    BlogCategoryName = "Networking"
                };

                context.BlogCategory.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.BlogCategory.Any(t => t.BlogCategoryName == "Other"))
            {
                BlogCategory toAdd = new BlogCategory
                {
                    BlogCategoryName = "Other"
                };

                context.BlogCategory.Add(toAdd);
                context.SaveChanges();
            }

            //this is where the BlogStatuses are 
            if (!context.BlogStatus.Any(t => t.BlogStatusDescription == "Draft"))
            {
                BlogStatus toAdd = new BlogStatus
                {
                    BlogStatusDescription = "Draft"
                };

                context.BlogStatus.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.BlogStatus.Any(t => t.BlogStatusDescription == "Pending"))
            {
                BlogStatus toAdd = new BlogStatus
                {
                    BlogStatusDescription = "Pending"
                };

                context.BlogStatus.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.BlogStatus.Any(t => t.BlogStatusDescription == "Published"))
            {
                BlogStatus toAdd = new BlogStatus
                {
                    BlogStatusDescription = "Published"
                };

                context.BlogStatus.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.BlogStatus.Any(t => t.BlogStatusDescription == "Removed"))
            {
                BlogStatus toAdd = new BlogStatus
                {
                    BlogStatusDescription = "Removed"
                };

                context.BlogStatus.Add(toAdd);
                context.SaveChanges();
            }

            //this is where the seed BlogPosts are

            if (!context.BlogPost.Any(t => t.Title == "JavaScriptMn, Monthly Meet Up"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "JavaScriptMn, Monthly Meet Up",
                    EventDate = new DateTime(2017, 10, 27),
                    BlogContent = "At tonights event we learned about Angular Universal and server side rendering",
                    DateStart = new DateTime(2017, 10, 26),
                    DateEnd = new DateTime(2018, 10, 26),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Technical"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Draft"),
                    IsFeatured = true,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Lindsey")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost1 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "JavaScriptMn, Monthly Meet Up");

            if (workingPost1.Hashtags == null)
            {
                workingPost1.Hashtags = new List<Hashtag>();
            }

            var hashtag1 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#VirtualReality");
            if (!workingPost1.Hashtags.Any(t => t.HashtagName == "#VirtualReality"))
            {
                workingPost1.Hashtags.Add(hashtag1);
                context.SaveChanges();
            }

            //-------------------------------------------------------
            if (!context.BlogPost.Any(t => t.Title == "Hack-o-Thon"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "Hack-o-Thon",
                    EventDate = new DateTime(2017, 10, 31),
                    BlogContent = "A haunting night with the annual Hack-o-Thon hostsed by Target Virtual Reality department. We were able to tour a haunting house",
                    DateStart = new DateTime(2017, 11, 01),
                    DateEnd = new DateTime(2018, 02, 28),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Other"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Published"),
                    IsFeatured = true,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Judy")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost2 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "Hack-o-Thon");

            if (workingPost2.Hashtags == null)
            {
                workingPost2.Hashtags = new List<Hashtag>();
            }

            var hashtag2 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#TallBoys");
            if (!workingPost2.Hashtags.Any(t => t.HashtagName == "#TallBoys"))
            {
                workingPost2.Hashtags.Add(hashtag2);
                context.SaveChanges();
            }

            var hashtag21 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#HashBrowns");
            if (!workingPost2.Hashtags.Any(t => t.HashtagName == "#HashBrowns"))
            {
                workingPost2.Hashtags.Add(hashtag21);
                context.SaveChanges();
            }

            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "Grace Hopper Viewing party"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "Grace Hopper Viewing party",
                    EventDate = new DateTime(2017, 10, 27),
                    BlogContent = "At tonights events we learned about Angular Universal and server side rendering",
                    DateStart = new DateTime(2017, 10, 26),
                    DateEnd = new DateTime(2018, 10, 26),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Technical"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Draft"),
                    IsFeatured = true,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Judy")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost3 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "Grace Hopper Viewing party");

            if (workingPost3.Hashtags == null)
            {
                workingPost3.Hashtags = new List<Hashtag>();
            }

            var hashtag3 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#HashBrowns");
            if (!workingPost3.Hashtags.Any(t => t.HashtagName == "#HashBrowns"))
            {
                workingPost3.Hashtags.Add(hashtag3);
                context.SaveChanges();
            }

            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "Ruby Rails"))
            {
                BlogPost toAdd = new BlogPost
                {

                    Title = "Ruby Rails",
                    EventDate = new DateTime(2017, 08, 01),
                    BlogContent = "Tonights workshoped some of the new features of Ruby Rails. Guest speaker Aj Rhode gave an in depth view of these tools",
                    DateStart = new DateTime(2017, 08, 02),
                    DateEnd = new DateTime(2017, 10, 31),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Networking"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Removed"),
                    IsFeatured = false,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Lindsey")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }


            BlogPost workingPost4 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "Ruby Rails");

            if (workingPost4.Hashtags == null)
            {
                workingPost4.Hashtags = new List<Hashtag>();
            }

            var hashtag4 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#HashBrowns");
            if (!workingPost4.Hashtags.Any(t => t.HashtagName == "#HashBrowns"))
            {
                workingPost4.Hashtags.Add(hashtag4);
                context.SaveChanges();
            }

            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "People who Truffle Shuffles"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "People who Truffle Shuffles",
                    EventDate = new DateTime(2017, 11, 01),
                    BlogContent = "Tonights workshop was hosted by us. In this even we spoil fellow shufflers with our delicate truffles",
                    DateStart = new DateTime(2017, 11, 02),
                    DateEnd = new DateTime(2018, 11, 03),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Social"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Removed"),
                    IsFeatured = false,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Lindsey")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost5 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "People who Truffle Shuffles");

            if (workingPost5.Hashtags == null)
            {
                workingPost5.Hashtags = new List<Hashtag>();
            }

            var hashtag5 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#HashBrowns");
            if (!workingPost5.Hashtags.Any(t => t.HashtagName == "#HashBrowns"))
            {
                workingPost5.Hashtags.Add(hashtag5);
                context.SaveChanges();
            }


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

            if (!userMgr.Users.Any(u => u.UserName == "JudyThao"))
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
            //return;
        }
    }

}
