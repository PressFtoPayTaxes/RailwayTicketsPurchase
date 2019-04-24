using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayTicketsPurchaseApp.Models
{
    public class Ticket : Entity
    {
        public virtual Route Route { get; set; }
        public int PlaceNumber { get; set; }
        public virtual Passenger PassengerInfo { get; set; }
        public bool IsBought { get; set; }
    }
}
