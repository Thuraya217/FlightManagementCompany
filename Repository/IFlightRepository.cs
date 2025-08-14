using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IFlightRepository
    {
        void AddFlight(Flight flight);
        void DeleteFlight(int id);
        IEnumerable<Flight> GetAllFlights();
        Flight GetFlightById(int id);
        List<Flight> GetFlightsByDateRange(DateTime from, DateTime to);
        List<Flight> GetFlightsByRoute(int routeId);
        void UpdateFlight(Flight flight);
    }
}