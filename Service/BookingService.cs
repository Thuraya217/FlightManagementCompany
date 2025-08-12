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
        private readonly BookingRepository _repo;

        public BookingService(FlightDbContext db)
        {
            _repo = new BookingRepository(db);
        }
    }
}
