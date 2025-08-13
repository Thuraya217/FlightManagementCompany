using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class AirportService
    {
        private readonly AirportRepository _repo;

        public AirportService(FlightDbContext db)
        {
            _repo = new AirportRepository(db);
        }

        public void CreateSampleAirports()
        {
            if (!_repo.GetAllAirports().Any())
            {
                var airports = new List<Airport>
                {
                        new Airport { Name = "Heathrow Airport", City = "London", Country = "UK", IATA = "LHR", TimeZone = "GMT" },
                        new Airport { Name = "John F. Kennedy International", City = "New York", Country = "USA", IATA = "JFK", TimeZone = "EST" },
                        new Airport { Name = "Dubai International", City = "Dubai", Country = "UAE", IATA = "DXB", TimeZone = "GST" },
                        new Airport { Name = "Tokyo Haneda", City = "Tokyo", Country = "Japan", IATA = "HND", TimeZone = "JST" },
                        new Airport { Name = "Sydney Kingsford Smith", City = "Sydney", Country = "Australia", IATA = "SYD", TimeZone = "AEST" },
                        new Airport { Name = "Muscat International", City = "Muscat", Country = "Oman", IATA = "MCT", TimeZone = "GST" },
                        new Airport { Name = "Los Angeles International", City = "Los Angeles", Country = "USA", IATA = "LAX", TimeZone = "PST" },
                        new Airport { Name = "Frankfurt Airport", City = "Frankfurt", Country = "Germany", IATA = "FRA", TimeZone = "CET" },
                        new Airport { Name = "Changi Airport", City = "Singapore", Country = "Singapore", IATA = "SIN", TimeZone = "SGT" },
                        new Airport { Name = "Doha Hamad International", City = "Doha", Country = "Qatar", IATA = "DOH", TimeZone = "AST" }
                };

                // Add sample airports to the repository
                foreach (var airport in airports)
                {
                    _repo.AddAirport(airport);
                }
            }
        }
    }
}
