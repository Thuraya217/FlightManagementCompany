using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class BookingService
    {
        private readonly BookingRepository _bookingRepo;
        private readonly PassengerRepository _passengerRepo;

        public BookingService(FlightDbContext db)
        {
            _bookingRepo = new BookingRepository(db);
            _passengerRepo = new PassengerRepository(db);
        }

        public List<Booking> CreateSampleBookings(int count = 100)
        {
            if (_bookingRepo.GetAllBookings().Any())
                return _bookingRepo.GetAllBookings().ToList();

            var random = new Random();
            var passengers = _passengerRepo.GetAllPassengers().ToList();
            var bookings = new List<Booking>();

            for (int i = 1; i <= count; i++)
            {
                var passenger = passengers[random.Next(passengers.Count)];
                var booking = new Booking
                {
                    BookingRef = "BKG" + i.ToString("D4"),
                    BookingDate = DateTime.UtcNow.AddDays(-random.Next(60)),
                    Status = "Confirmed",
                    PassengerId = passenger.PassengerId
                };

                _bookingRepo.AddBooking(booking);
                bookings.Add(booking);
            }

            Console.WriteLine($"Seeded {bookings.Count} bookings.");
            return bookings;
        }
    }
}

