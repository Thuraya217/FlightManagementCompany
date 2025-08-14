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
    public class FlightService
    {
        private readonly FlightRepository _FlightRepo;

        public FlightService(FlightDbContext db)
        {
            _FlightRepo = new FlightRepository(db);
        }

        public IEnumerable<FlightManifestDto> GetDailyManifest(DateTime date)
        {
            return _FlightRepo.GetAllFlights()
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
                        }).ToList()
                }).ToList();
        }

        public double OnTimePerformance(DateTime start, DateTime end, int thresholdMinutes = 15)
        {
            var flights = _FlightRepo.GetAllFlights()
                .Where(f => f.DepartureUtc >= start && f.DepartureUtc <= end)
                .ToList();

            if (!flights.Any()) return 0;

            var onTime = flights.Count(f => Math.Abs((f.ArrivalUtc - f.DepartureUtc).TotalMinutes) <= thresholdMinutes);
            return (double)onTime / flights.Count * 100;
        }

        public IEnumerable<(string FlightNumber, double Occupancy)> HighOccupancyFlights(double threshold = 0.8)
        {
            return _FlightRepo.GetAllFlights()
                .Select(f => new
                {
                    f.FlightNumber,
                    Occupancy = (double)f.Tickets.Count / f.Aircraft.Capacity
                })
                .Where(f => f.Occupancy > threshold)
                .Select(f => (f.FlightNumber, f.Occupancy))
                .ToList();
        }

        public IEnumerable<string> GetAvailableSeats(int flightId)
        {
            var flight = _FlightRepo.GetAllFlightsQuery()
                .Include(f => f.Tickets)
                .Include(f => f.Aircraft)
                .First(f => f.FlightId == flightId);

            var bookedSeats = flight.Tickets.Select(t => t.SeatNumber).ToList();

            var allSeats = Enumerable.Range(1, flight.Aircraft.Capacity)
                .SelectMany(row => "ABCDEF".Select(seat => $"{row}{seat}"))
                .Take(flight.Aircraft.Capacity)
                .ToList();

            return allSeats.Except(bookedSeats);
        }

        public IEnumerable<(DateTime Date, decimal RunningRevenue)> RunningRevenue()
        {
            var dailyRevenue = _FlightRepo.GetAllFlights()
                .SelectMany(f => f.Tickets)
                .GroupBy(t => t.Flight.DepartureUtc.Date)
                .OrderBy(g => g.Key)
                .Select(g => new { Date = g.Key, Revenue = g.Sum(t => t.Fare) })
                .ToList();

            decimal cumulative = 0;
            return dailyRevenue.Select(d => (d.Date, cumulative += d.Revenue)).ToList();
        }
    }
}

