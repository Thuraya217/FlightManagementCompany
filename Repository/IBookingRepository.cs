using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        void DeleteBooking(int id);
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int id);
        List<Booking> GetBookingsByDateRange(DateTime from, DateTime to);
        void UpdateBooking(Booking booking);
    }
}