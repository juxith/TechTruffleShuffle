namespace TechTruffleShuffle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
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
                        AuthorId = c.Int(nullable: false),
                        Description = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        BlogCategoryId = c.Int(nullable: false),
                        BlogStatusId = c.Int(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                        IsStaticPage = c.Boolean(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BlogPostId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategoryId)
                .ForeignKey("dbo.BlogStatus", t => t.BlogStatusId)
                .Index(t => t.AuthorId)
                .Index(t => t.BlogCategoryId)
                .Index(t => t.BlogStatusId);
            
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
                "dbo.HashtagBlogPosts",
                c => new
                    {
                        Hashtag_HashtagId = c.Int(nullable: false),
                        BlogPost_BlogPostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hashtag_HashtagId, t.BlogPost_BlogPostId })
                .ForeignKey("dbo.Hashtags", t => t.Hashtag_HashtagId)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPost_BlogPostId)
                .Index(t => t.Hashtag_HashtagId)
                .Index(t => t.BlogPost_BlogPostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HashtagBlogPosts", "BlogPost_BlogPostId", "dbo.BlogPosts");
            DropForeignKey("dbo.HashtagBlogPosts", "Hashtag_HashtagId", "dbo.Hashtags");
            DropForeignKey("dbo.BlogPosts", "BlogStatusId", "dbo.BlogStatus");
            DropForeignKey("dbo.BlogPosts", "BlogCategoryId", "dbo.BlogCategories");
            DropForeignKey("dbo.BlogPosts", "AuthorId", "dbo.Authors");
            DropIndex("dbo.HashtagBlogPosts", new[] { "BlogPost_BlogPostId" });
            DropIndex("dbo.HashtagBlogPosts", new[] { "Hashtag_HashtagId" });
            DropIndex("dbo.BlogPosts", new[] { "BlogStatusId" });
            DropIndex("dbo.BlogPosts", new[] { "BlogCategoryId" });
            DropIndex("dbo.BlogPosts", new[] { "AuthorId" });
            DropTable("dbo.HashtagBlogPosts");
            DropTable("dbo.Hashtags");
            DropTable("dbo.BlogStatus");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.Authors");
        }
    }
}
