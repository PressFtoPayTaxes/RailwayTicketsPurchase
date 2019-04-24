namespace RailwayTicketsPurchaseApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        DestinationStation_Id = c.Guid(),
                        StartStation_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stations", t => t.DestinationStation_Id)
                .ForeignKey("dbo.Stations", t => t.StartStation_Id)
                .Index(t => t.DestinationStation_Id)
                .Index(t => t.StartStation_Id);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PlaceNumber = c.Int(nullable: false),
                        PassengerInfo_Id = c.Guid(),
                        Route_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passengers", t => t.PassengerInfo_Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .Index(t => t.PassengerInfo_Id)
                .Index(t => t.Route_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Route_Id", "dbo.Routes");
            DropForeignKey("dbo.Tickets", "PassengerInfo_Id", "dbo.Passengers");
            DropForeignKey("dbo.Routes", "StartStation_Id", "dbo.Stations");
            DropForeignKey("dbo.Routes", "DestinationStation_Id", "dbo.Stations");
            DropIndex("dbo.Tickets", new[] { "Route_Id" });
            DropIndex("dbo.Tickets", new[] { "PassengerInfo_Id" });
            DropIndex("dbo.Routes", new[] { "StartStation_Id" });
            DropIndex("dbo.Routes", new[] { "DestinationStation_Id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Stations");
            DropTable("dbo.Routes");
            DropTable("dbo.Passengers");
        }
    }
}
