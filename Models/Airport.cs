using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    [Index(nameof(IATA), IsUnique = true)]

    public class Airport
    {
        [Key]
        public int AirportId { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [Required]
        [MaxLength(3)]
        public string IATA { get; set; } // International Air Transport Association code
        public string TimeZone { get; set; } // Time zone of the airport

        public ICollection<Route> OriginRoutes { get; set; } // start routes from this airport
        public ICollection<Route> DestinationRoutes { get; set; } // end routes at this airport
    }
}
