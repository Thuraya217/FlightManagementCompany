using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public class AirportRepository
    {
        private readonly FlightDbContext _db;

        public AirportRepository(FlightDbContext db)
        {
            _db = db;
        }

        // Add methods for managing airports here
        public void AddAirport(Airport airport)
        {
            _db.Airports.Add(airport);
            _db.SaveChanges();
        }

        public void UpdateAirport(Airport airport)
        {
            _db.Airports.Update(airport);
            _db.SaveChanges();
        }

        public void DeleteAirport(int id)
        {
            var airport = _db.Airports.Find(id);
            if (airport != null)
            {
                _db.Airports.Remove(airport);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Airport> GetAllAirports() => _db.Airports.ToList();
        public Airport GetAirportById(int id) => _db.Airports.Find(id);
    }
}
