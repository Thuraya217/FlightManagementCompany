using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public class BaggageRepository : IBaggageRepository
    {
        private readonly FlightDbContext _db;

        public BaggageRepository(FlightDbContext db)
        {
            _db = db;
        }

        // Add methods for baggage management 
        public void AddBaggage(Baggage baggage)
        {
            _db.Baggages.Add(baggage);
            _db.SaveChanges();
        }

        public void UpdateBaggage(Baggage baggage)
        {
            _db.Baggages.Update(baggage);
            _db.SaveChanges();
        }

        public void DeleteBaggage(int id)
        {
            var baggage = _db.Baggages.Find(id);
            if (baggage != null)
            {
                _db.Baggages.Remove(baggage);
                _db.SaveChanges();
            }
        }

        public void AddRangeBaggage(List<Baggage> baggageList)
        {
            _db.Baggages.AddRange(baggageList);
            _db.SaveChanges();
        }

        public IEnumerable<Baggage> GetAllBaggages() => _db.Baggages.ToList();
        public Baggage GetBaggageById(int id) => _db.Baggages.Find(id);
    }
}
