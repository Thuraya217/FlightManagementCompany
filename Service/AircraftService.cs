using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlightManagementCompany.Service
{
    public class AircraftService
    {
        private readonly AircraftRepository _repo;

        public AircraftService(FlightDbContext db)
        {
            _repo = new AircraftRepository(db);
        }

        public void CreateSampleAircrafts()
        {
            if (!_repo.GetAircraft().Any())
            {
                var Aircrafts = new List<Aircraft>
                {
                        new Aircraft { TailNumber = "A1001", Model = "Boeing 737", Capacity = 150 },
                        new Aircraft { TailNumber = "A1002", Model = "Airbus A320", Capacity = 180 },
                        new Aircraft { TailNumber = "A1003", Model = "Boeing 787 Dreamliner", Capacity = 250 },
                        new Aircraft { TailNumber = "A1004", Model = "Airbus A350", Capacity = 300 },
                        new Aircraft { TailNumber = "A1005", Model = "Embraer E190", Capacity = 100 },
                        new Aircraft { TailNumber = "A1006", Model = "Bombardier CS300", Capacity = 130 },
                        new Aircraft { TailNumber = "A1007", Model = "Boeing 777", Capacity = 280 },
                        new Aircraft { TailNumber = "A1008", Model = "Airbus A321", Capacity = 200 },
                        new Aircraft { TailNumber = "A1009", Model = "Boeing 757", Capacity = 180 },
                        new Aircraft { TailNumber = "A1010", Model = "McDonnell Douglas MD-80", Capacity = 160 }
                };

                // Add sample aircrafts to the repository
                foreach (var a in Aircrafts)
                {
                    _repo.AddAircraft(a);
                }
            }
        }
    }
}
