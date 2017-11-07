namespace TechTruffleShuffle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        BlogCategoryId = c.Int(nullable: false, identity: true),
                        BlogCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.BlogCategoryId);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        BlogPostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        BlogContent = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        BlogCategoryId = c.Int(nullable: false),
                        BlogStatusId = c.Int(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                        IsStaticPage = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BlogPostId)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.BlogStatus", t => t.BlogStatusId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.BlogCategoryId)
                .Index(t => t.BlogStatusId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.BlogStatus",
                c => new
                    {
                        BlogStatusId = c.Int(nullable: false, identity: true),
                        BlogStatusDescription = c.String(),
                    })
                .PrimaryKey(t => t.BlogStatusId);
            
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        HashtagId = c.Int(nullable: false, identity: true),
                        HashtagName = c.String(),
                    })
                .PrimaryKey(t => t.HashtagId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.HashtagBlogPosts",
                c => new
                    {
                        Hashtag_HashtagId = c.Int(nullable: false),
                        BlogPost_BlogPostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hashtag_HashtagId, t.BlogPost_BlogPostId })
                .ForeignKey("dbo.Hashtags", t => t.Hashtag_HashtagId, cascadeDelete: true)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPost_BlogPostId, cascadeDelete: true)
                .Index(t => t.Hashtag_HashtagId)
                .Index(t => t.BlogPost_BlogPostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BlogPosts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HashtagBlogPosts", "BlogPost_BlogPostId", "dbo.BlogPosts");
            DropForeignKey("dbo.HashtagBlogPosts", "Hashtag_HashtagId", "dbo.Hashtags");
            DropForeignKey("dbo.BlogPosts", "BlogStatusId", "dbo.BlogStatus");
            DropForeignKey("dbo.BlogPosts", "BlogCategoryId", "dbo.BlogCategories");
            DropIndex("dbo.HashtagBlogPosts", new[] { "BlogPost_BlogPostId" });
            DropIndex("dbo.HashtagBlogPosts", new[] { "Hashtag_HashtagId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BlogPosts", new[] { "User_Id" });
            DropIndex("dbo.BlogPosts", new[] { "BlogStatusId" });
            DropIndex("dbo.BlogPosts", new[] { "BlogCategoryId" });
            DropTable("dbo.HashtagBlogPosts");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Hashtags");
            DropTable("dbo.BlogStatus");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.BlogCategories");
        }
    }
}
