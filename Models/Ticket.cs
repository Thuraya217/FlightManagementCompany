using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public string SeatNumber { get; set; }
        public decimal Fare { get; set; }
        public bool CheckedIn {  get; set; }

        // Foreign key to the Booking entity
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public Booking Booking { get; set; } // Navigation property to the Booking entity

        // Foreign key to the flight entity
        [ForeignKey("Flight")]
        public int FlightId { get; set; } // Foreign key to the Flight entity
        public Flight Flight { get; set; } // Navigation property to the Flight entity

        public ICollection<Baggage> Baggages { get; set; } // Collection of baggage associated with the ticket
    }
}
