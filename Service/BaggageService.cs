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
    public class BaggageService
    {
        private readonly BaggageRepository _BaggageRepo;

        public BaggageService(FlightDbContext db)
        {
            _BaggageRepo = new BaggageRepository(db);
        }

    

    }
}
