using RailwayTicketsPurchaseApp.DataAccess;
using RailwayTicketsPurchaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayTicketsPurchaseApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("---------------Выберите маршрут---------------");
            var handler = new DatabaseHandler();

            //handler.AddRoute(new Station
            //{
            //    Name = "Огневка",
            //    Latitude = 35.2,
            //    Longitude = 41.2
            //},
            //new Station
            //{
            //    Name = "Нур-Султан",
            //    Latitude = 24.2,
            //    Longitude = 73.7
            //}, DateTime.Now, 40);

            var routes = handler.GetAllRoutes();

            for (int i = 0; i < routes.Count; i++)
                System.Console.WriteLine($"{i + 1}: {routes[i].StartStation.Name} - {routes[i].DestinationStation.Name} {routes[i].Date}");

            Route selectedRoute = new Route();
            while(true)
            {
                int answer = int.Parse(System.Console.ReadLine());
                if(answer > 0 && answer <= routes.Count)
                {
                    selectedRoute = routes[answer - 1];
                    break;
                }
                System.Console.WriteLine("Такого номера нет");
            }

            System.Console.WriteLine("Выберите место:");

            var places = handler.GetFreePlaces(selectedRoute);
            for (int i = 0; i < places.Count; i++)
            {
                System.Console.Write(places[i] + " ");
                if((i + 1) % 15 == 0)
                    System.Console.WriteLine();
            }
            System.Console.WriteLine();

            int selectedPlace = int.Parse(System.Console.ReadLine());

            var passenger = new Passenger();
            
            while(passenger.Name == null || passenger.Name == string.Empty)
            {
                System.Console.Write("Введите свое имя: ");
                passenger.Name = System.Console.ReadLine();
            }
            while (passenger.PhoneNumber == null || passenger.PhoneNumber == string.Empty)
            {
                System.Console.Write("Введите свой номер телефона: ");
                passenger.PhoneNumber = System.Console.ReadLine();
            }

            handler.BuyTicket(passenger, selectedRoute, selectedPlace);
            System.Console.WriteLine("Билет куплен");
        }
    }
}
