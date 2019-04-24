namespace RailwayTicketsPurchaseApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "PlacesCount", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "IsBought", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "IsBought");
            DropColumn("dbo.Routes", "PlacesCount");
        }
    }
}
