namespace BeerTap.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKegState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kegs", "KegState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kegs", "KegState");
        }
    }
}
