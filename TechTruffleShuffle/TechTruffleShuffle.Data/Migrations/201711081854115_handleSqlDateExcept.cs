namespace TechTruffleShuffle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class handleSqlDateExcept : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "DateStart", c => c.DateTime());
            AlterColumn("dbo.BlogPosts", "DateEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogPosts", "DateEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BlogPosts", "DateStart", c => c.DateTime(nullable: false));
        }
    }
}
