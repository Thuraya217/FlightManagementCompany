using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class TicketService
    {
        private readonly TicketRepository _repo;

        public TicketService(FlightDbContext db)
        {
            _repo = new TicketRepository(db);
        }
    }
}
