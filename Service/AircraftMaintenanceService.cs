using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class AircraftMaintenanceService
    {
        private readonly AircraftMaintenanceRepository _repo;

        public AircraftMaintenanceService(FlightDbContext db)
        {
            _repo = new AircraftMaintenanceRepository(db);
        }

        public void CreateSampleAircraftMaintenances()
        {
            if (!_repo.GetAllAircraftMaintenance().Any())
            {
                var aircraftMaintenances = new List<AircraftMaintenance>
                {
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-50), Type = "Routine",   Notes = "Regular 6-month checkup completed successfully.", AircraftId = 1 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-45), Type = "Emergency", Notes = "Engine vibration detected, replaced faulty component.", AircraftId = 2 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-40), Type = "Routine",   Notes = "Cabin pressure system tested and approved.", AircraftId = 3 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-38), Type = "Routine",   Notes = "Landing gear lubrication and testing.", AircraftId = 1 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-35), Type = "Emergency", Notes = "Hydraulic leak fixed after pre-flight inspection.", AircraftId = 4 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-30), Type = "Routine",   Notes = "Avionics software updated to latest version.", AircraftId = 5 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-28), Type = "Routine",   Notes = "Fuel system inspection and cleaning.", AircraftId = 6 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-25), Type = "Routine",   Notes = "Oxygen masks tested and replaced if necessary.", AircraftId = 7 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-20), Type = "Emergency", Notes = "Electrical system short-circuit fixed.", AircraftId = 8 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-18), Type = "Routine",   Notes = "Passenger seating checked for safety compliance.", AircraftId = 9 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-15), Type = "Routine",   Notes = "External cleaning and paint touch-up.", AircraftId = 10 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-12), Type = "Routine",   Notes = "Replaced worn tires on landing gear.", AircraftId = 2 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-10), Type = "Routine",   Notes = "Emergency evacuation slides tested.", AircraftId = 3 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-8),  Type = "Emergency", Notes = "In-flight entertainment system repaired.", AircraftId = 5 },
                        new AircraftMaintenance { MaintenanceDate = DateTime.UtcNow.AddDays(-5),  Type = "Routine",   Notes = "Cockpit instruments calibrated.", AircraftId = 6 }
                };

                // Add sample aircraft maintenance records to the repository
                foreach (var am in aircraftMaintenances)
                {
                    _repo.AddAircraftMaintenanced(am);
                }
            }
        }
    }
}
