using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public class RouteRepository
    {
        private readonly FlightDbContext _db;

        public RouteRepository(FlightDbContext db)
        {
            _db = db;
        }

        // Add methods for route management
        public void AddRoute(Route route)
        {
            _db.Routes.Add(route);
            _db.SaveChanges();
        }

        public void UpdateRoute(Route route)
        {
            _db.Routes.Update(route);
            _db.SaveChanges();
        }

        public void DeleteRoute(int id)
        {
            var route = _db.Routes.Find(id);
            if (route != null)
            {
                _db.Routes.Remove(route);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Route> GetAllRoutes() => _db.Routes.ToList();
        public Route GetRouteById(int id) => _db.Routes.Find(id);

    }
}
