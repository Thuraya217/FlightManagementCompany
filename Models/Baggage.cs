using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Baggage
    {
        [Key]
        public int BaggageId { get; set; }

        [Required]
        public decimal WeightKg { get; set; } // Weight of the baggage in kilograms

        [Required]
        public string TagNumber { get; set; } // Unique tag number for the baggage

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } // Navigation property to the Ticket entity
    }
}
