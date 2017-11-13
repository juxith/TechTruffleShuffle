namespace TechTruffleShuffle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableEventDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "EventDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogPosts", "EventDate", c => c.DateTime(nullable: false));
        }
    }
}
