using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class AircraftMaintenanceService
    {
        private readonly AircraftMaintenanceRepository _repo;

        public AircraftMaintenanceService(FlightDbContext db)
        {
            _repo = new AircraftMaintenanceRepository(db);
        }
    }
}
