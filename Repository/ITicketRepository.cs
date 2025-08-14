using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface ITicketRepository
    {
        void AddTicket(Ticket ticket);
        void DeleteTicket(int id);
        IEnumerable<Ticket> GetAllTickets();
        List<Ticket> GetTickesByPassenger(int passengerId);
        Ticket GetTicketById(int id);
        List<Ticket> GetTicketsByBooking(string bookingRef);
        void UpdateTicket(Ticket ticket);
    }
}