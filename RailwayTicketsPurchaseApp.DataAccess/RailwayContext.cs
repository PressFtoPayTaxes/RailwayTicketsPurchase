namespace RailwayTicketsPurchaseApp.DataAccess
{
    using RailwayTicketsPurchaseApp.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RailwayContext : DbContext
    {
        public RailwayContext()
            : base("name=RailwayContext")
        {
        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}