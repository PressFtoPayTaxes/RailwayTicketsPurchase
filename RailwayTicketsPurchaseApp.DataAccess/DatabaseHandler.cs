using RailwayTicketsPurchaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayTicketsPurchaseApp.DataAccess
{
    public class DatabaseHandler
    {
        public void AddRoute(Station startStation, Station finishStation, DateTime date, int placesCount)
        {
            using (var context = new RailwayContext())
            {
                var newRoute = new Route
                {
                    StartStation = startStation,
                    DestinationStation = finishStation,
                    Date = date,
                    PlacesCount = placesCount
                };

                context.Routes.Add(newRoute);

                for (int i = 0; i < newRoute.PlacesCount; i++)
                {
                    context.Tickets.Add(new Ticket
                    {
                        Route = newRoute,
                        PlaceNumber = i + 1,
                        IsBought = false
                    });
                }
                context.SaveChanges();
            }
        }

        public void BuyTicket(Passenger passenger, Route route, int placeNumber)
        {
            using (var context = new RailwayContext())
            {
                foreach (var ticket in context.Tickets)
                    if (ticket.Route == route && ticket.PlaceNumber == placeNumber)
                    {
                        ticket.PassengerInfo = passenger;
                        ticket.IsBought = true;
                        break;
                    }
                context.SaveChanges();
            }
        }

        public List<int> GetFreePlaces(Route route)
        {
            var places = new List<int>();

            using (var context = new RailwayContext())
                foreach (var place in context.Tickets)
                    if (place.Route == route && !place.IsBought)
                        places.Add(place.PlaceNumber);

            return places;
        }

        public List<Route> GetAllRoutes()
        {
            var routes = new List<Route>();

            using (var context = new RailwayContext())
                routes = context.Routes.ToList();

            return routes;
        }
    }
}
