using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementCompany.Models;
using Microsoft.EntityFrameworkCore;


namespace FlightManagementCompany.Repository
{
    public class AircraftMaintenanceRepository : IAircraftMaintenanceRepository
    {
        private readonly FlightDbContext _db;

        public AircraftMaintenanceRepository(FlightDbContext db)
        {
            _db = db;
        }

        public void AddAircraftMaintenanced(AircraftMaintenance aircraftMaintenance)
        {
            _db.AircraftMaintenances.Add(aircraftMaintenance);
            _db.SaveChanges();
        }

        public void UpdateAircraftMaintenance(AircraftMaintenance aircraftMaintenance)
        {
            _db.AircraftMaintenances.Update(aircraftMaintenance);
            _db.SaveChanges();
        }

        public void DeleteAircraftMaintenance(int id)
        {
            var aircraftMaintenance = _db.AircraftMaintenances.Find(id);
            if (aircraftMaintenance != null)
            {
                _db.AircraftMaintenances.Remove(aircraftMaintenance);
                _db.SaveChanges();
            }
        }

        public IEnumerable<AircraftMaintenance> GetAllAircraftMaintenance() => _db.AircraftMaintenances.ToList();
        public AircraftMaintenance GetAircraftMaintenanceById(int id) => _db.AircraftMaintenances.Find(id);
    }
}
