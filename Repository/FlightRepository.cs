using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public class FlightRepository
    {
        private readonly FlightDbContext _db;

        public FlightRepository(FlightDbContext db)
        {
            _db = db;
        }

        // Add methods for flight management
        public void AddFlight(Flight flight)
        {
            _db.Flights.Add(flight);
            _db.SaveChanges();
        }

        public void UpdateFlight(Flight flight)
        {
            _db.Flights.Update(flight);
            _db.SaveChanges();
        }

        public void DeleteFlight(int id)
        {
            var flight = _db.Flights.Find(id);
            if (flight != null)
            {
                _db.Flights.Remove(flight);
                _db.SaveChanges();
            }
        }

        public List<Flight> GetFlightsByDateRange(DateTime from, DateTime to)
        {
            return _db.Flights
                 .Where(f => f.DepartureUtc <= to && f.ArrivalUtc >= from)
                 .ToList();
        }

        public List<Flight> GetFlightsByRoute(int routeId)
        {
            return _db.Flights
                .Where(f => f.RouteId == routeId)
                .ToList();
        }

        public IEnumerable<Flight> GetAllFlights() => _db.Flights.ToList();
        public Flight GetFlightById(int id) => _db.Flights.Find(id);
    }
}
