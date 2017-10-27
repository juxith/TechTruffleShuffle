namespace TechTruffleShuffle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPosts", "BlogContent", c => c.String());
            AddColumn("dbo.BlogPosts", "EventDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.BlogPosts", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogPosts", "Description", c => c.String());
            DropColumn("dbo.BlogPosts", "EventDate");
            DropColumn("dbo.BlogPosts", "BlogContent");
        }
    }
}
