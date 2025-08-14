using FlightManagementCompany.Models;
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
        private readonly AirportRepository _AirportRepo;

        public AirportService(FlightDbContext db)
        {
            _AirportRepo = new AirportRepository(db);
        }
    }
}
