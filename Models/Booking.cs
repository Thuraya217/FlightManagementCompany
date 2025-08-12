using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    [Index(nameof(BookingRef), IsUnique = true)]

    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public string BookingRef { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public string Status { get; set; }

        [ForeignKey("Passenger")]
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; } // Navigation property to the Passenger entity

        // one booking can have multiple tickets
        public ICollection<Ticket> Tickets { get; set; } // Navigation property to the collection of Tickets associated with this Booking

    }
}
