using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class BookingService
    {
        private readonly BookingRepository _bookingRepo;

        public BookingService(FlightDbContext db)
        {
            _bookingRepo = new BookingRepository(db);
        }
    }
}

