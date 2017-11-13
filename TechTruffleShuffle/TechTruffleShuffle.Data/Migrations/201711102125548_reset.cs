namespace TechTruffleShuffle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reset : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "EventDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogPosts", "EventDate", c => c.DateTime());
        }
    }
}
