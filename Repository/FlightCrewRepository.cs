using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public class FlightCrewRepository : IFlightCrewRepository
    {
        private readonly FlightDbContext _db;

        public FlightCrewRepository(FlightDbContext db)
        {
            _db = db;
        }

        // Add methods for flight crew management
        public void AddFlightCrew(FlightCrew flightCrew)
        {
            _db.FlightCrews.Add(flightCrew);
            _db.SaveChanges();
        }

        public void UpdateFlightCrew(FlightCrew flightCrew)
        {
            _db.FlightCrews.Update(flightCrew);
            _db.SaveChanges();
        }

        public void DeleteFlightCrew(int id)
        {
            var flightCrew = _db.FlightCrews.Find(id);
            if (flightCrew != null)
            {
                _db.FlightCrews.Remove(flightCrew);
                _db.SaveChanges();
            }
        }

        public IEnumerable<FlightCrew> GetAllFlightCrews() => _db.FlightCrews.ToList();
        public FlightCrew GetFlightCrewById(int id) => _db.FlightCrews.Find(id);
    }
}
