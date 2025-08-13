using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class RouteService
    {
        private readonly RouteRepository _repo;

        public RouteService(FlightDbContext db)
        {
            _repo = new RouteRepository(db);
        }

        public void CreateSampleRoutes()
        {
            if (!_repo.GetAllRoutes().Any())
            {
                var routes = new List<Route>
                {
                    new Route { OriginAirportId = 1, DestinationAirportId = 2, DistanceKm = 540 },
                    new Route { OriginAirportId = 1, DestinationAirportId = 3, DistanceKm = 1200 },
                    new Route { OriginAirportId = 2, DestinationAirportId = 4, DistanceKm = 680 },
                    new Route { OriginAirportId = 2, DestinationAirportId = 5, DistanceKm = 300 },
                    new Route { OriginAirportId = 3, DestinationAirportId = 6, DistanceKm = 1500 },
                    new Route { OriginAirportId = 3, DestinationAirportId = 7, DistanceKm = 800 },
                    new Route { OriginAirportId = 4, DestinationAirportId = 8, DistanceKm = 400 },
                    new Route { OriginAirportId = 5, DestinationAirportId = 9, DistanceKm = 1100 },
                    new Route { OriginAirportId = 6, DestinationAirportId = 10, DistanceKm = 900 },
                    new Route { OriginAirportId = 7, DestinationAirportId = 1, DistanceKm = 1400 },
                    new Route { OriginAirportId = 8, DestinationAirportId = 2, DistanceKm = 600 },
                    new Route { OriginAirportId = 9, DestinationAirportId = 3, DistanceKm = 700 },
                    new Route { OriginAirportId = 10, DestinationAirportId = 4, DistanceKm = 1300 },
                    new Route { OriginAirportId = 1, DestinationAirportId = 5, DistanceKm = 550 },
                    new Route { OriginAirportId = 2, DestinationAirportId = 6, DistanceKm = 1250 },
                    new Route { OriginAirportId = 3, DestinationAirportId = 8, DistanceKm = 1000 },
                    new Route { OriginAirportId = 4, DestinationAirportId = 7, DistanceKm = 1150 },
                    new Route { OriginAirportId = 5, DestinationAirportId = 9, DistanceKm = 980 },
                    new Route { OriginAirportId = 6, DestinationAirportId = 10, DistanceKm = 850 },
                    new Route { OriginAirportId = 7, DestinationAirportId = 1, DistanceKm = 1450 }
                };

                // Add sample routes to the repository
                foreach (var route in routes)
                {
                    _repo.AddRoute(route);
                }
            }
        }
    }
}
