using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class PassengerService
    {
        private readonly PassengerRepository _repo;

        public PassengerService(FlightDbContext db)
        {
            _repo = new PassengerRepository(db);
        }
    }
}
