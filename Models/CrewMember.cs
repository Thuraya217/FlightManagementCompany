using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    // Represents the Role of a crew member in a flight
    public enum CrewRole
    {
        Pilot,
        CoPilot,
        FlightAttendant
    }
    public class CrewMember
    {
        [Key]
        public int CrewId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EnumDataType(typeof(CrewRole))]
        public CrewRole Role { get; set; } // e.g., Pilot, CoPilot, FlightAttendant

        // ? can be null
        public string? LicenseNumber { get; set; } // For pilots, the license number

        public virtual ICollection<FlightCrew> FlightCrews { get; set; } // Collection of flight crew assignments for this crew member
    }
}
