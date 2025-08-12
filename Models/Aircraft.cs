using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    // Aircraft entity representing an aircraft in the flight management system
    [Index(nameof(TailNumber), IsUnique = true)]

    public class Aircraft
    {
        [Key]
        public int AircraftId { get; set; }

        [Required]  
        public string TailNumber { get; set; } // Unique identifier for the aircraft

        [Required]
        public string Model { get; set; } 
        public int Capacity { get; set; } // Number of passengers the aircraft can carry

        public ICollection <AircraftMaintenance> AircraftMaintenances { get; set; } // Collection of maintenance records associated with the aircraft
        public ICollection<Flight> Flights { get; set; } // Collection of flights associated with the aircraft
    }
}
