using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IBaggageRepository
    {
        void AddBaggage(Baggage baggage);
        void AddRangeBaggage(List<Baggage> baggageList);
        void DeleteBaggage(int id);
        IEnumerable<Baggage> GetAllBaggages();
        Baggage GetBaggageById(int id);
        void UpdateBaggage(Baggage baggage);
    }
}