using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly FlightDbContext _db;

        public BookingRepository(FlightDbContext db)
        {
            _db = db;
        }

        // Add methods for booking management
        public void AddBooking(Booking booking)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            _db.Bookings.Update(booking);
            _db.SaveChanges();
        }

        public void DeleteBooking(int id)
        {
            var booking = _db.Bookings.Find(id);
            if (booking != null)
            {
                _db.Bookings.Remove(booking);
                _db.SaveChanges();
            }
        }

        public List<Booking> GetBookingsByDateRange(DateTime from, DateTime to)
        {
            var bookings = _db.Bookings
                .Where(b => b.BookingDate >= from && b.BookingDate <= to)
                .ToList();

            return bookings;
        }

        public IEnumerable<Booking> GetAllBookings() => _db.Bookings.ToList();
        public Booking GetBookingById(int id) => _db.Bookings.Find(id);
    }
}
