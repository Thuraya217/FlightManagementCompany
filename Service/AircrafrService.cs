using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlightManagementCompany.Service
{
    public class AircrafrService
    {
        private readonly AircraftRepository _repo;

        public AircrafrService(FlightDbContext db)
        {
            _repo = new AircraftRepository (db);
        }
    }
}
