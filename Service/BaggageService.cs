using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class BaggageService
    {
        private readonly BaggageRepository _repo;

        public BaggageService(FlightDbContext db)
        {
            _repo = new BaggageRepository(db);
        }
    }
}
