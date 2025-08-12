using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class AirportService
    {
        private readonly AirportRepository _repo;

        public AirportService(FlightDbContext db)
        {
            _repo = new AirportRepository(db);
        }
    }
}
