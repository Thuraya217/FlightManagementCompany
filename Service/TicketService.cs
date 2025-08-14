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
    public class TicketService
    {
        private readonly TicketRepository _ticketRepo;

        public TicketService(FlightDbContext db)
        {
            _ticketRepo = new TicketRepository(db);
        }

        public IEnumerable<Ticket> OverweightBaggageAlerts(decimal maxKg = 30)
        {
            return _ticketRepo.GetAllTickets()
                .Where(t => t.Baggages.Sum(b => b.WeightKg) > maxKg)
                .ToList();
        }
    }
}


