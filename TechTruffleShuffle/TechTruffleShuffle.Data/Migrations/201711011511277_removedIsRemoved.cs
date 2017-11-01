namespace TechTruffleShuffle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedIsRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BlogPosts", "IsRemoved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogPosts", "IsRemoved", c => c.Boolean(nullable: false));
        }
    }
}
