using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class PassengerService
    {
        private readonly PassengerRepository _repo;

        public PassengerService(FlightDbContext db)
        {
            _repo = new PassengerRepository(db);
        }

        public List<Passenger> CreateSamplePassengers(int count = 50)
        {
            if (_repo.GetAllPassengers().Any())
                return _repo.GetAllPassengers().ToList();

            var random = new Random();
            var nationalities = new[] { "USA", "UK", "Canada", "Germany", "France", "India", "China", "Brazil", "Australia", "Egypt" };
            var passengers = new List<Passenger>();

            for (int i = 1; i <= count; i++)
            {
                var passenger = new Passenger
                {
                    FullName = $"Passenger {i}",
                    PassportNumber = "P" + i.ToString("D5"),
                    Nationality = nationalities[random.Next(nationalities.Length)],
                    DateOfBirth = DateTime.UtcNow.AddYears(-random.Next(18, 70))
                };

                _repo.AddPassenger(passenger);
                passengers.Add(passenger);
            }

            Console.WriteLine($"Seeded {passengers.Count} passengers.");
            return passengers;
        }
    }
}

