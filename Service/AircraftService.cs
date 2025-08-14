using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlightManagementCompany.Service
{
    public class AircraftService
    {
        private readonly AircraftRepository _AircraftRepo;

        public AircraftService(FlightDbContext db)
        {
            _AircraftRepo = new AircraftRepository(db);
        }

        public IEnumerable<Aircraft> MaintenanceAlert(double maxHours = 1000, int maxDays = 180)
        {
            double avgSpeedKmH = 800; // simulate speed
            var today = DateTime.UtcNow;

            var aircrafts = _AircraftRepo.GetAllAircrafts(); 

            return aircrafts
                .Where(a =>
                    a.Flights.Sum(f => f.Route.DistanceKm) / avgSpeedKmH > maxHours ||
                    a.AircraftMaintenances
                     .OrderByDescending(m => m.MaintenanceDate)
                     .FirstOrDefault()?.MaintenanceDate < today.AddDays(-maxDays)
                ).ToList();
        }
    }
}
 