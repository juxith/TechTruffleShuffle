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

            if (!context.Hashtag.Any(t => t.HashtagName == "#Learning"))
            {
                Hashtag toAdd = new Hashtag
                {
                    HashtagName = "#Learning"
                };

                context.Hashtag.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.Hashtag.Any(t => t.HashtagName == "#OOP"))
            {
                Hashtag toAdd = new Hashtag
                {
                    HashtagName = "#OOP"
                };

                context.Hashtag.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.Hashtag.Any(t => t.HashtagName == "#InIt2WinIt"))
            {
                Hashtag toAdd = new Hashtag
                {
                    HashtagName = "#InIt2WinIt"
                };

                context.Hashtag.Add(toAdd);
                context.SaveChanges();
            }

            if (!context.Hashtag.Any(t => t.HashtagName == "#CodeMaster"))
            {
                Hashtag toAdd = new Hashtag
                {
                    HashtagName = "#CodeMaster"
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
            if (!context.BlogStatus.Any(t => t.BlogStatusDescription == "Static"))
            {
                BlogStatus toAdd = new BlogStatus
                {
                    BlogStatusDescription = "Static"
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
                    User = context.Users.SingleOrDefault(n => n.UserName == "LindseyParlow")
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

            var hashtag2b = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#HashBrowns");
            if (!workingPost2.Hashtags.Any(t => t.HashtagName == "#HashBrowns"))
            {
                workingPost2.Hashtags.Add(hashtag2b);
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


            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "We are Getting Close to the End!"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "We are Getting Close to the End!",
                    EventDate = new DateTime(2017, 10, 31),
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Networking"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Draft"),
                    IsFeatured = false,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Lindsey")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost6 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "We are Getting Close to the End!");

            if (workingPost6.Hashtags == null)
            {
                workingPost6.Hashtags = new List<Hashtag>();
            }

            var hashtag6 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#Learning");
            if (!workingPost6.Hashtags.Any(t => t.HashtagName == "#Learning"))
            {
                workingPost6.Hashtags.Add(hashtag6);
                context.SaveChanges();
            }
            var hashtag6b = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#InIt2WinIt");
            if (!workingPost6.Hashtags.Any(t => t.HashtagName == "#InIt2WinIt"))
            {
                workingPost6.Hashtags.Add(hashtag6b);
                context.SaveChanges();
            }

            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "Let's Bust a Move"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "Let's Bust a Move",
                    EventDate = new DateTime(2017, 10, 31),
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Social"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Pending"),
                    IsFeatured = false,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Lindsey")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost7 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "Let's Bust a Move");

            if (workingPost7.Hashtags == null)
            {
                workingPost7.Hashtags = new List<Hashtag>();
            }

            var hashtag7 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#TallBoys");
            if (!workingPost7.Hashtags.Any(t => t.HashtagName == "#TallBoys"))
            {
                workingPost7.Hashtags.Add(hashtag7);
                context.SaveChanges();
            }

            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "Tech it with your best shot"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "Tech it with your best shot",
                    EventDate = new DateTime(2017, 10, 31),
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Technical"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Published"),
                    IsFeatured = true,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Judy")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost8 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "Tech it with your best shot");

            if (workingPost8.Hashtags == null)
            {
                workingPost8.Hashtags = new List<Hashtag>();
            }

            var hashtag8 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#OOP");
            if (!workingPost8.Hashtags.Any(t => t.HashtagName == "#OOP"))
            {
                workingPost8.Hashtags.Add(hashtag8);
                context.SaveChanges();
            }
            var hashtag8b = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#CodeMaster");
            if (!workingPost8.Hashtags.Any(t => t.HashtagName == "#CodeMaster"))
            {
                workingPost8.Hashtags.Add(hashtag8b);
                context.SaveChanges();
            }

            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "C# is Awesome. We are Awesome."))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "C# is Awesome. We are Awesome.",
                    EventDate = new DateTime(2017, 10, 31),
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Technical"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Removed"),
                    IsFeatured = true,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Lindsey")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost9 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "C# is Awesome. We are Awesome.");

            if (workingPost9.Hashtags == null)
            {
                workingPost9.Hashtags = new List<Hashtag>();
            }

            var hashtag9 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#CodeMaster");
            if (!workingPost9.Hashtags.Any(t => t.HashtagName == "#CodeMaster"))
            {
                workingPost9.Hashtags.Add(hashtag9);
                context.SaveChanges();
            }

            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "Just keep swimming, just keep swimming"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "Just keep swimming, just keep swimming",
                    EventDate = new DateTime(2017, 10, 31),
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Social"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Draft"),
                    IsFeatured = false,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Lindsey")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost10 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "Just keep swimming, just keep swimming");

            if (workingPost10.Hashtags == null)
            {
                workingPost10.Hashtags = new List<Hashtag>();
            }

            var hashtag10 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#Learning");
            if (!workingPost10.Hashtags.Any(t => t.HashtagName == "#Learning"))
            {
                workingPost10.Hashtags.Add(hashtag10);
                context.SaveChanges();
            }
            var hashtag10b = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#TallBoys");
            if (!workingPost10.Hashtags.Any(t => t.HashtagName == "#TallBoys"))
            {
                workingPost10.Hashtags.Add(hashtag10b);
                context.SaveChanges();
            }

            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "Networking Tips for Newbies"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "Networking Tips for Newbies",
                    EventDate = new DateTime(2017, 10, 31),
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Networking"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Removed"),
                    IsFeatured = true,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Judy")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost11 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "Networking Tips for Newbies");

            if (workingPost11.Hashtags == null)
            {
                workingPost11.Hashtags = new List<Hashtag>();
            }

            var hashtag11 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#Learning");
            if (!workingPost11.Hashtags.Any(t => t.HashtagName == "#Learning"))
            {
                workingPost11.Hashtags.Add(hashtag11);
                context.SaveChanges();
            }
            var hashtag11b = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#InIt2WinIt");
            if (!workingPost11.Hashtags.Any(t => t.HashtagName == "#InIt2WinIt"))
            {
                workingPost11.Hashtags.Add(hashtag11b);
                context.SaveChanges();
            }

            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "Get all the jobs!!!"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "Get all the jobs!!!",
                    EventDate = new DateTime(2017, 10, 31),
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Networking"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Pending"),
                    IsFeatured = false,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Lindsey")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost12 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "Get all the jobs!!!");

            if (workingPost12.Hashtags == null)
            {
                workingPost12.Hashtags = new List<Hashtag>();
            }

            var hashtag12 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#InIt2WinIt");
            if (!workingPost12.Hashtags.Any(t => t.HashtagName == "#InIt2WinIt"))
            {
                workingPost12.Hashtags.Add(hashtag12);
                context.SaveChanges();
            }

            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "Learn a new language with Lindsey"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "Learn a new language with Lindsey",
                    EventDate = new DateTime(2017, 10, 31),
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Technical"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Published"),
                    IsFeatured = true,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Lindsey")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost13 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "Learn a new language with Lindsey");

            if (workingPost13.Hashtags == null)
            {
                workingPost13.Hashtags = new List<Hashtag>();
            }

            var hashtag13 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#Learning");
            if (!workingPost13.Hashtags.Any(t => t.HashtagName == "#Learning"))
            {
                workingPost13.Hashtags.Add(hashtag13);
                context.SaveChanges();
            }

            var hashtag13b = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#OOP");
            if (!workingPost13.Hashtags.Any(t => t.HashtagName == "#OOP"))
            {
                workingPost13.Hashtags.Add(hashtag13b);
                context.SaveChanges();
            }

            var hashtag13c = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#CodeMaster");
            if (!workingPost13.Hashtags.Any(t => t.HashtagName == "#CodeMaster"))
            {
                workingPost13.Hashtags.Add(hashtag13c);
                context.SaveChanges();
            }


            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "Angular. The Next Frontier"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "Angular. The Next Frontier",
                    EventDate = new DateTime(2017, 10, 31),
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Technical"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Published"),
                    IsFeatured = false,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Judy")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost14 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "Angular. The Next Frontier");

            if (workingPost14.Hashtags == null)
            {
                workingPost14.Hashtags = new List<Hashtag>();
            }

            var hashtag14 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#CodeMaster");
            if (!workingPost14.Hashtags.Any(t => t.HashtagName == "#CodeMaster"))
            {
                workingPost14.Hashtags.Add(hashtag14);
                context.SaveChanges();
            }

            //=============================================================================

            if (!context.BlogPost.Any(t => t.Title == "Social Time!"))
            {
                BlogPost toAdd = new BlogPost
                {
                    Title = "Social Time!",
                    EventDate = new DateTime(2017, 10, 31),
                    BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. ",
                    DateStart = new DateTime(2017, 9, 01),
                    DateEnd = new DateTime(2018, 9, 01),
                    BlogCategory = context.BlogCategory.SingleOrDefault(b => b.BlogCategoryName == "Social"),
                    BlogStatus = context.BlogStatus.SingleOrDefault(s => s.BlogStatusDescription == "Published"),
                    IsFeatured = false,
                    IsStaticPage = false,
                    User = context.Users.SingleOrDefault(n => n.FirstName == "Judy")
                };
                context.BlogPost.Add(toAdd);
                context.SaveChanges();
            }

            BlogPost workingPost15 = context.BlogPost.Include(p => p.Hashtags).SingleOrDefault(p => p.Title == "Social Time!");

            if (workingPost15.Hashtags == null)
            {
                workingPost15.Hashtags = new List<Hashtag>();
            }

            var hashtag15 = context.Hashtag.SingleOrDefault(h => h.HashtagName == "#TallBoys");
            if (!workingPost15.Hashtags.Any(t => t.HashtagName == "#TallBoys"))
            {
                workingPost15.Hashtags.Add(hashtag15);
                context.SaveChanges();
            }


            context.SaveChanges();
            //return;
        }
    }

}
