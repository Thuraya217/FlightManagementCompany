using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class FlightService
    {
        private readonly FlightRepository _repo;

        public FlightService(FlightDbContext db)
        {
            _repo = new FlightRepository(db);
        }
    }
}
