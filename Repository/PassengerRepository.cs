using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public class PassengerRepository
    {
        private readonly FlightDbContext _db;

        public PassengerRepository(FlightDbContext db)
        {
            _db = db;
        }

        // Add methods for passenger management
        public void AddPassenger(Passenger passenger)
        {
            _db.Passengers.Add(passenger);
            _db.SaveChanges();
        }

        public void UpdatePassenger(Passenger passenger)
        {
            _db.Passengers.Update(passenger);
            _db.SaveChanges();
        }

        public void DeletePassenger(int id)
        {
            var passenger = _db.Passengers.Find(id);
            if (passenger != null)
            {
                _db.Passengers.Remove(passenger);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Passenger> GetAllPassengers() => _db.Passengers.ToList();
        public Passenger GetPassengerById(int id) => _db.Passengers.Find(id);
    }
}
