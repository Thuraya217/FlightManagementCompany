using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    // FlightCrew entity representing the crew members assigned to a flight meny to meny
    [PrimaryKey(nameof(FlightId), nameof(CrewId))]
    public class FlightCrew
    {
        public string RoleOnFlight { get; set; } // Role of the crew member on the flight (e.g., Pilot, Flight Attendant)
       
        [ForeignKey("CrewMember")]
        public int CrewId { get; set; } // Foreign key to the CrewMember entity
        public virtual CrewMember CrewMember { get; set; } // Navigation property to the CrewMember entity

        [ForeignKey("Flight")]
        public int FlightId { get; set; } // Foreign key to the Flight entity
        public virtual Flight Flight { get; set; } // Navigation property to the Flight entity


    }
}
