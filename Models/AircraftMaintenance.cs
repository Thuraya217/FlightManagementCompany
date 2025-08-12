using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class AircraftMaintenance
    {
        [Key]
        public int MaintenanceId { get; set; }

        [Required]
        public DateTime MaintenanceDate { get; set; } // Date of the maintenance

        [Required]
        public string Type { get; set; } // Type of maintenance (e.g., Routine, Emergency)

        [MaxLength(500)]
        public string Notes { get; set; } // Additional notes or details about the maintenance

        [ForeignKey("Aircraft")]
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; } // Navigation property to the Aircraft entity
    }
}
