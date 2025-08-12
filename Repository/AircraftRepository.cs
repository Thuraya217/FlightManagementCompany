using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class AircraftRepository
    {
        private readonly FlightDbContext _db;

        public AircraftRepository(FlightDbContext db)
        {
            _db = db;
        }

        public void AddAircraft(Aircraft aircraft)
        {
            _db.Aircrafts.Add(aircraft);
            _db.SaveChanges();
        }

        public void UpdateAircraft(Aircraft aircraft)
        {
            _db.Aircrafts.Update(aircraft);
            _db.SaveChanges();
        }

        public void DeleteAircraft(int id)
        {
            var aircraft = _db.Aircrafts.Find(id);
            if (aircraft != null)
            {
                _db.Aircrafts.Remove(aircraft);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Aircraft> GetAircraft() => _db.Aircrafts.ToList();
        public Aircraft GetAircraftById(int id) => _db.Aircrafts.Find(id);
    }
}
