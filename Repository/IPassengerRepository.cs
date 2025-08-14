using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IPassengerRepository
    {
        void AddPassenger(Passenger passenger);
        void DeletePassenger(int id);
        IEnumerable<Passenger> GetAllPassengers();
        Passenger GetPassengerById(int id);
        void UpdatePassenger(Passenger passenger);
    }
}