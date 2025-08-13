using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public class TicketRepository
    {
        private readonly FlightDbContext _db;

        public TicketRepository(FlightDbContext db)
        {
            _db = db;
        }

        // Add methods for ticket management
        public void AddTicket(Ticket ticket)
        {
            _db.Tickets.Add(ticket);
            _db.SaveChanges();
        }

        public void UpdateTicket(Ticket ticket)
        {
            _db.Tickets.Update(ticket);
            _db.SaveChanges();
        }

        public void DeleteTicket(int id)
        {
            var Ticket = _db.Tickets.Find(id);
            if (Ticket != null)
            {
                _db.Tickets.Remove(Ticket);
                _db.SaveChanges();
            }
        }

        public List <Ticket> GetTicketsByBooking (string bookingRef)
        {
            return _db.Tickets
                .Where(t => t.Booking.BookingRef == bookingRef)
                .ToList();
        }

        public List <Ticket> GetTickesByPassenger (int passengerId)
        {
            return _db.Tickets
                .Where(t => t.Booking.PassengerId == passengerId)
                .ToList();
        }

        public IEnumerable<Ticket> GetAllTickets() => _db.Tickets.ToList();
        public Ticket GetTicketById(int id) => _db.Tickets.Find(id);
    }
}
