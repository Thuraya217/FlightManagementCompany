using FlightManagementCompany.Models;
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
        private readonly TicketRepository _ticketRepo;

        public BaggageService(FlightDbContext db)
        {
            _repo = new BaggageRepository(db);
            _ticketRepo = new TicketRepository(db);
        }

        public void CreateSampleBaggages()
        {
            if (!_repo.GetAllBaggages().Any()) return;
            
                var random = new Random();
                var tickets = _ticketRepo.GetAllTickets().ToList();
                var baggageList = new List<Baggage>();

            foreach (var ticket in tickets)
            {
                int bagsCount = random.Next(0, 3);
                for (int i = 0; i < bagsCount; i++)
                {
                    baggageList.Add(new Baggage
                    {
                        TicketId = ticket.TicketId,
                        WeightKg = Math.Round((decimal)(random.Next(5, 30) + random.NextDouble()), 2),
                        TagNumber = "TAG" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()
                    });
                }
            }

            while (baggageList.Count < 150)
            {
                var ticket = tickets[random.Next(tickets.Count)];
                baggageList.Add(new Baggage
                {
                    TicketId = ticket.TicketId,
                    WeightKg = Math.Round((decimal)(random.Next(5, 30) + random.NextDouble()), 2),
                    TagNumber = "TAG" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()
                });
            }

            _repo.AddRangeBaggage(baggageList);
        }
    }
}
