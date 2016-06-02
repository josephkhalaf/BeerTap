namespace BeerTap.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfficeIdKeg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kegs", "OfficeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Kegs", "OfficeId");
            AddForeignKey("dbo.Kegs", "OfficeId", "dbo.Offices", "OfficeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kegs", "OfficeId", "dbo.Offices");
            DropIndex("dbo.Kegs", new[] { "OfficeId" });
            DropColumn("dbo.Kegs", "OfficeId");
        }
    }
}
