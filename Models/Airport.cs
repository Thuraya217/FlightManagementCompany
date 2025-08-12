using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Airport
    {
        public int AirportId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string IATA { get; set; } // International Air Transport Association code
        public string ICAO { get; set; } // International Civil Aviation Organization code
        public string TimeZone { get; set; } // Time zone of the airport
    }
}
