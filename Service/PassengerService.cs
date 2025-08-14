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
    public class PassengerService
    {
        private readonly PassengerRepository _PassengerRepo;

        public PassengerService(FlightDbContext db)
        {
            _PassengerRepo = new PassengerRepository(db);
        }
        public IEnumerable<PassengerItineraryDto> PassengersWithConnections(int maxHoursBetween = 6)
        {
            return _PassengerRepo.GetAllPassengers()
                .Where(p => p.Bookings.Any())
                .Select(p => new PassengerItineraryDto
                {
                    PassengerId = p.PassengerId,
                    PassengerName = p.FullName,
                    Segments = p.Bookings
                        .SelectMany(b => b.Tickets)
                        .OrderBy(t => t.Flight.DepartureUtc)
                        .Select(t => new ItinSegmentDto
                        {
                            FlightId = t.FlightId,
                            FlightNumber = t.Flight.FlightNumber,
                            Origin = t.Flight.Route.OriginAirport.IATA,
                            Destination = t.Flight.Route.DestinationAirport.IATA,
                            DepartureUtc = t.Flight.DepartureUtc,
                            ArrivalUtc = t.Flight.ArrivalUtc,
                            AircraftTail = t.Flight.Aircraft.TailNumber
                        }).ToList()
                })
                .Where(p => p.Segments.Count > 1)
                .ToList();
        }

        public IEnumerable<(string PassengerName, int FlightsCount, int TotalDistance)> FrequentFliers(int topN = 10)
        {
            return _PassengerRepo.GetAllPassengers()
                .Select(p => new
                {
                    p.FullName,
                    FlightsCount = p.Bookings.SelectMany(b => b.Tickets).Count(),
                    TotalDistance = p.Bookings.SelectMany(b => b.Tickets)
                                              .Sum(t => t.Flight.Route.DistanceKm)
                })
                .OrderByDescending(x => x.FlightsCount)
                .Take(topN)
                .Select(x => (x.FullName, x.FlightsCount, x.TotalDistance))
                .ToList();
        }

        public decimal ForecastNextWeekBookings()
        {
            var bookings = _PassengerRepo.GetAllPassengers()
                .SelectMany(p => p.Bookings)
                .Where(b => b.BookingDate >= DateTime.UtcNow.AddDays(-7))
                .Count();

            return bookings / 7m;
        }
    }
}

