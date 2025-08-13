using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class FlightService
    {
        private readonly FlightRepository _repo;
        private readonly RouteRepository _routeRepo;
        private readonly AircraftRepository _aircraftRepo;

        public FlightService(FlightDbContext db)
        {
            _repo = new FlightRepository(db);
            _routeRepo = new RouteRepository(db);
            _aircraftRepo = new AircraftRepository(db);
        }

        public void CreateSampleFlights()
        {
            if (_repo.GetAllFlights().Any()) return;

            var random = new Random();
            var routes = _routeRepo.GetAllRoutes().ToList();
            var aircrafts = _aircraftRepo.GetAllAircrafts().ToList();

            var flights = new List<Flight>();

            for (int i = 1; i <= 30; i++)
            {
                var route = routes[random.Next(routes.Count)];
                var aircraft = aircrafts[random.Next(aircrafts.Count)];

                var departure = DateTime.UtcNow.AddDays(random.Next(30, 61))
                                                .AddHours(random.Next(0, 24))
                                                .AddMinutes(random.Next(0, 60));

                var arrival = departure.AddHours(random.Next(1, 6));

                var statusValues = Enum.GetValues(typeof(FlightStatus));
                var status = (FlightStatus)statusValues.GetValue(random.Next(statusValues.Length));

                flights.Add(new Flight
                {
                    FlightNumber = "FL" + i.ToString("D3"),
                    DepartureUtc = departure,
                    ArrivalUtc = arrival,
                    Status = status,
                    RouteId = route.RouteId,
                    AircraftId = aircraft.AircraftId
                });
            }

            foreach (var flight in flights)
            {
                _repo.AddFlight(flight);
            }
        }

            public IEnumerable<FlightManifestDto> GetDailyFlightManifest(DateTime date)
            {
                var flights = _repo.GetAllFlights()
                    .Where(f => f.DepartureUtc.Date == date.Date)
                    .Select(f => new FlightManifestDto
                    {
                        FlightNumber = f.FlightNumber,
                        DepUtc = f.DepartureUtc,
                        ArrUtc = f.ArrivalUtc,
                        Origin = f.Route.OriginAirport.IATA,
                        Destination = f.Route.DestinationAirport.IATA,
                        AircraftTail = f.Aircraft.TailNumber,
                        PassengerCount = f.Tickets.Count(),
                        TotalBaggageKg = f.Tickets.SelectMany(t => t.Baggages).Sum(b => b.WeightKg),
                        Crew = f.FlightCrews
                                .Select(fc => new CrewDto
                                {
                                    CrewName = fc.CrewMember.FullName,
                                    Role = fc.CrewMember.Role.ToString()
                                })
                                .ToList()
                    });

                return flights;
            }


        public IEnumerable<RouteRevenueDto> GetTopRoutesByRevenue(DateTime from, DateTime to)
        {
            var result = _repo.GetAllFlights()
                .Where(f => f.DepartureUtc.Date >= from.Date && f.ArrivalUtc.Date <= to.Date)
                .GroupBy(f => f.RouteId) 
                .Select(g =>
                {
                    var route = g.First().Route; 
                    var tickets = g.SelectMany(f => f.Tickets); 
                    var revenue = tickets.Sum(t => t.Fare);
                    var seatsSold = tickets.Count();
                    var avgFare = seatsSold > 0 ? revenue / seatsSold : 0;

                    return new RouteRevenueDto
                    {
                        RouteId = g.Key,
                        Origin = route.OriginAirport.IATA,
                        Destination = route.DestinationAirport.IATA,
                        Revenue = revenue,
                        SeatsSold = seatsSold,
                        AvgFare = avgFare
                    };
                })
                .OrderByDescending(r => r.Revenue); 

            return result;
        }
    }
}

