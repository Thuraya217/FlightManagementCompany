using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    [Index(nameof(PassportNumber), IsUnique = true)]

    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        [Required]  
        public string FullName { get; set; } // Full name of the passenger

        [Required]
        public string PassportNumber { get; set; } // Unique passport number
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; } // Date of birth of the passenger

        public ICollection<Booking> Bookings { get; set; } // Collection of bookings associated with the passenger
    }
}
