using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class FlightCrewService
    {
        private readonly FlightCrewRepository _repo;

        public FlightCrewService(FlightDbContext db)
        {
            _repo = new FlightCrewRepository(db);
        }
    }
}
