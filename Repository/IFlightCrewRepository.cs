using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IFlightCrewRepository
    {
        void AddFlightCrew(FlightCrew flightCrew);
        void DeleteFlightCrew(int id);
        IEnumerable<FlightCrew> GetAllFlightCrews();
        FlightCrew GetFlightCrewById(int id);
        void UpdateFlightCrew(FlightCrew flightCrew);
    }
}