namespace BeerTap.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kegs",
                c => new
                    {
                        KegId = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KegId);
            
            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        OfficeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OfficeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Offices");
            DropTable("dbo.Kegs");
        }
    }
}
