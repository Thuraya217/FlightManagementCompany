using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class RouteService
    {
        private readonly RouteRepository _repo;

        public RouteService(FlightDbContext db)
        {
            _repo = new RouteRepository(db);
        }
    }
}
