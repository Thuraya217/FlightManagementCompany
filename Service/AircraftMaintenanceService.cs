using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class AircraftMaintenanceService
    {
        private readonly AircraftMaintenanceRepository _AircraftMaintenanceRepo;

        public AircraftMaintenanceService(FlightDbContext db)
        {
            _AircraftMaintenanceRepo = new AircraftMaintenanceRepository(db);
        }

     
    }
}
