using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IAircraftMaintenanceRepository
    {
        void AddAircraftMaintenanced(AircraftMaintenance aircraftMaintenance);
        void DeleteAircraftMaintenance(int id);
        AircraftMaintenance GetAircraftMaintenanceById(int id);
        IEnumerable<AircraftMaintenance> GetAllAircraftMaintenance();
        void UpdateAircraftMaintenance(AircraftMaintenance aircraftMaintenance);
    }
}