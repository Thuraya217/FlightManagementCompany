using FlightManagementCompany.Models;
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
        private readonly TicketRepository _ticketRepo;
        private readonly FlightRepository _flightRepo;

        public TicketService(FlightDbContext db)
        {
            _ticketRepo = new TicketRepository(db);
            _flightRepo = new FlightRepository(db);
        }

        public void CreateTicketsForBookings(List<Booking> bookings)
        {
            var random = new Random();
            var flights = _flightRepo.GetAllFlights().ToList();
            int totalTickets = 0;

            foreach (var booking in bookings)
            {
                int ticketsPerBooking = random.Next(1, 4); // 1-3 tickets per booking
                var usedFlights = new HashSet<int>();

                for (int t = 0; t < ticketsPerBooking; t++)
                {
                    Flight flight;
                    do
                    {
                        flight = flights[random.Next(flights.Count)];
                    } while (usedFlights.Contains(flight.FlightId));

                    usedFlights.Add(flight.FlightId);

                    var ticket = new Ticket
                    {
                        BookingId = booking.BookingId,
                        FlightId = flight.FlightId,
                        SeatNumber = $"{random.Next(1, flight.Aircraft.Capacity + 1)}A",
                        Fare = Math.Round((decimal)(random.Next(100, 1000) + random.NextDouble()), 2),
                        CheckedIn = false
                    };

                    _ticketRepo.AddTicket(ticket);
                    totalTickets++;
                }
            }

            Console.WriteLine($"Seeded {totalTickets} tickets for {bookings.Count} bookings.");
        }
    }
}


