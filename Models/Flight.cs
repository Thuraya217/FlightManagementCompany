using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    // Represents the status of a flight
    public enum FlightStatus
    {
        Scheduled,
        Delayed,
        Cancelled,
        Completed
    }
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public string FlightNumber { get; set; } // Unique flight number
        public DateTime DepartureUtc { get; set; } // Scheduled departure time in UTC
        public DateTime ArrivalUtc { get; set; } // Scheduled arrival time



        [EnumDataType(typeof(FlightStatus))]
        public FlightStatus Status { get; set; } // e.g., Scheduled, Delayed, Cancelled, Completed

        [ForeignKey("Route")]
        public int RouteId { get; set; }
        public Route Route { get; set; } // Navigation property to the Route entity

        [ForeignKey("Aircraft")]
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; } // Navigation property to the Aircraft entity

        public ICollection<Ticket> Tickets { get; set; } // Collection of tickets associated with the flight
        public virtual ICollection<FlightCrew> FlightCrews { get; set; } // Collection of flight crew members associated with the flight
    }
}
