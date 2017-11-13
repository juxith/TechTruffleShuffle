namespace TechTruffleShuffle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staticPageID : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StaticPages",
                c => new
                    {
                        StaticPageID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.StaticPageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StaticPages");
        }
    }
}
