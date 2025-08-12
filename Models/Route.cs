using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{

    public class Route
    {
        [Key]
        public int RouteId { get; set; } // Unique identifier for the route
        public int DistanceKm { get; set; } // Distance in kilometers 

        // FK for Origin Airport
        [ForeignKey("OriginAirport")]
        public int OriginAirportId { get; set; }
        public Airport OriginAirport { get; set; }

        // FK for Destination Airport
        [ForeignKey("DestinationAirport")]
        public int DestinationAirportId { get; set; }
        public Airport DestinationAirport { get; set; }

        public ICollection<Flight> Flights { get; set; } // Collection of flights associated with the route
    }
}
