using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IAircraftRepository
    {
        void AddAircraft(Aircraft aircraft);
        void DeleteAircraft(int id);
        Aircraft GetAircraftById(int id);
        List<Aircraft> GetAircraftDueForMaintenance(DateTime beforeDate);
        IEnumerable<Aircraft> GetAllAircrafts();
        void UpdateAircraft(Aircraft aircraft);
    }
}