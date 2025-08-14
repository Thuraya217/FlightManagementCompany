using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class RouteService
    {
        private readonly RouteRepository _RouteRepo;

        public RouteService(FlightDbContext db)
        {
            _RouteRepo = new RouteRepository(db);
        }

        public IEnumerable<RouteRevenueDto> TopRoutesByRevenue(DateTime start, DateTime end)
        {
            return _RouteRepo.GetAllRoutes()
                .Select(r => new RouteRevenueDto
                {
                    RouteId = r.RouteId,
                    Origin = r.OriginAirport.IATA,
                    Destination = r.DestinationAirport.IATA,
                    Revenue = r.Flights
                                .Where(f => f.DepartureUtc >= start && f.DepartureUtc <= end)
                                .SelectMany(f => f.Tickets)
                                .Sum(t => t.Fare),
                    SeatsSold = r.Flights
                                .Where(f => f.DepartureUtc >= start && f.DepartureUtc <= end)
                                .SelectMany(f => f.Tickets)
                                .Count(),
                    AvgFare = r.Flights
                                .Where(f => f.DepartureUtc >= start && f.DepartureUtc <= end)
                                .SelectMany(f => f.Tickets)
                                .DefaultIfEmpty()
                                .Average(t => t == null ? 0 : t.Fare)
                })
                .OrderByDescending(r => r.Revenue)
                .ToList();
        }
    }
}
