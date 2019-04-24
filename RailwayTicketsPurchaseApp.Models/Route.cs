using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayTicketsPurchaseApp.Models
{
    public class Route : Entity
    {
        public virtual Station StartStation { get; set; }
        public virtual Station DestinationStation { get; set; }
        public DateTime Date { get; set; }
        public int PlacesCount { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
