using FlightManagementCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class SeedData
    {
        public static void Initialize(FlightDbContext context)
        {
            context.Database.EnsureCreated();
            var rnd = new Random();

            // Airports data
            if (!context.Airports.Any())
            {
                context.Airports.AddRange(new List<Airport>
            {
                new Airport { Name = "Heathrow Airport", City = "London", Country = "UK", IATA = "LHR", TimeZone = "GMT" },
                new Airport { Name = "John F. Kennedy International", City = "New York", Country = "USA", IATA = "JFK", TimeZone = "EST" },
                new Airport { Name = "Dubai International", City = "Dubai", Country = "UAE", IATA = "DXB", TimeZone = "GST" },
                new Airport { Name = "Tokyo Haneda", City = "Tokyo", Country = "Japan", IATA = "HND", TimeZone = "JST" },
                new Airport { Name = "Sydney Kingsford Smith", City = "Sydney", Country = "Australia", IATA = "SYD", TimeZone = "AEST" },
                new Airport { Name = "Muscat International", City = "Muscat", Country = "Oman", IATA = "MCT", TimeZone = "GST" },
                new Airport { Name = "Los Angeles International", City = "Los Angeles", Country = "USA", IATA = "LAX", TimeZone = "PST" },
                new Airport { Name = "Frankfurt Airport", City = "Frankfurt", Country = "Germany", IATA = "FRA", TimeZone = "CET" },
                new Airport { Name = "Changi Airport", City = "Singapore", Country = "Singapore", IATA = "SIN", TimeZone = "SGT" },
                new Airport { Name = "Doha Hamad International", City = "Doha", Country = "Qatar", IATA = "DOH", TimeZone = "AST" }
            });
                context.SaveChanges();
            }

            //  Aircrafts data
            if (!context.Aircrafts.Any())
                if (!context.Aircrafts.Any())
                {
                    var aircrafts = Enumerable.Range(1, 10)
                        .Select(i => new Aircraft
                        {
                            Model = $"Boeing 7{i}7",
                            Capacity = rnd.Next(100, 301),
                            TailNumber = $"TN{i + 1:000}"
                        }).ToList();
                    context.Aircrafts.AddRange(aircrafts);
                    context.SaveChanges();
                }

            //  Crew Members data
            if (!context.CrewMembers.Any())
            {
                var roles = new[] { CrewRole.Pilot, CrewRole.CoPilot, CrewRole.FlightAttendant };

                var crew = Enumerable.Range(1, 20)
                    .Select(i => new CrewMember
                    {
                        FullName = $"Crew Member {i}",
                        Role = roles[i % roles.Length],
                        LicenseNumber = roles[i % roles.Length] == CrewRole.Pilot || roles[i % roles.Length] == CrewRole.CoPilot
                            ? $"LIC-{1000 + i}"
                            : null
                    }).ToList();

                context.CrewMembers.AddRange(crew);
                context.SaveChanges();
            }

            // Routes data
            if (!context.Routes.Any())
            {
                var airports = context.Airports.ToList();
                var routes = new List<Route>();
                while (routes.Count < 20)
                {
                    var origin = airports[rnd.Next(airports.Count)];
                    var destination = airports[rnd.Next(airports.Count)];
                    if (origin.AirportId != destination.AirportId &&
                        !routes.Any(r => r.OriginAirportId == origin.AirportId && r.DestinationAirportId == destination.AirportId))
                    {
                        routes.Add(new Route
                        {
                            OriginAirportId = origin.AirportId,
                            DestinationAirportId = destination.AirportId,
                            DistanceKm = rnd.Next(300, 10000)
                        });
                    }
                }
                context.Routes.AddRange(routes);
                context.SaveChanges();
            }

            // Flights data
            if (!context.Flights.Any())
            {
                var routes = context.Routes.ToList();
                var aircrafts = context.Aircrafts.ToList();
                var flights = new List<Flight>();
                for (int i = 0; i < 30; i++)
                {
                    var route = routes[rnd.Next(routes.Count)];
                    var aircraft = aircrafts[rnd.Next(aircrafts.Count)];
                    var depTime = DateTime.UtcNow.AddDays(rnd.Next(-15, 45)).AddHours(rnd.Next(0, 24));
                    var statusValues = Enum.GetValues(typeof(FlightStatus));
                    var status = (FlightStatus)statusValues.GetValue(rnd.Next(statusValues.Length));

                    flights.Add(new Flight
                    {
                        FlightNumber = $"FL{i + 1:000}",
                        RouteId = route.RouteId,
                        AircraftId = aircraft.AircraftId,
                        DepartureUtc = depTime,
                        ArrivalUtc = depTime.AddHours(rnd.Next(2, 15)),
                        Status = status
                    });
                }
                context.Flights.AddRange(flights);
                context.SaveChanges();
            }

            // Passengers data
            if (!context.Passengers.Any())
            {
                var nationalities = new[] { "UK", "USA", "UAE", "Japan", "Australia", "Oman", "Germany", "Singapore", "Qatar" };
                var passengers = Enumerable.Range(1, 50)
                    .Select(i => new Passenger
                    {
                        FullName = $"Passenger {i}",
                        Nationality = nationalities[i % nationalities.Length],
                        PassportNumber = $"P{i:00000}",
                        DateOfBirth = DateTime.UtcNow.AddYears(-rnd.Next(18, 60))
                    }).ToList();
                context.Passengers.AddRange(passengers);
                context.SaveChanges();
            }

            // Bookings & Tickets data
            if (!context.Bookings.Any())
            {
                var flights = context.Flights.ToList();
                var passengers = context.Passengers.ToList();
                var bookings = new List<Booking>();
                var tickets = new List<Ticket>();
                for (int i = 0; i < 100; i++)
                {
                    var passenger = passengers[rnd.Next(passengers.Count)];
                    var booking = new Booking
                    {
                        PassengerId = passenger.PassengerId,
                        BookingDate = DateTime.UtcNow.AddDays(-rnd.Next(0, 30)),
                        Status = "Confirmed",
                        BookingRef = $"BR{i + 1:0000}"
                    };
                    bookings.Add(booking);
                }
                context.Bookings.AddRange(bookings);
                context.SaveChanges();

                int seatNumCounter = 1;
                foreach (var booking in bookings)
                {
                    int ticketsCount = rnd.Next(1, 3);
                    for (int j = 0; j < ticketsCount; j++)
                    {
                        var flight = flights[rnd.Next(flights.Count)];
                        tickets.Add(new Ticket
                        {
                            BookingId = booking.BookingId,
                            FlightId = flight.FlightId,
                            SeatNumber = $"{seatNumCounter}{(char)('A' + (seatNumCounter % 6))}",
                            Fare = Math.Round((decimal)(rnd.Next(100, 1000) + rnd.NextDouble()), 2),
                            CheckedIn = false
                        });
                        seatNumCounter++;
                    }
                }
                context.Tickets.AddRange(tickets);
                context.SaveChanges();
            }

            // Baggage data
            if (!context.Baggages.Any())
            {
                var tickets = context.Tickets.ToList();
                var baggages = new List<Baggage>();
                for (int i = 0; i < 150; i++)
                {
                    var ticket = tickets[rnd.Next(tickets.Count)];
                    baggages.Add(new Baggage
                    {
                        TicketId = ticket.TicketId,
                        WeightKg = rnd.Next(5, 40),
                        TagNumber = $"BAG{i + 1:0000}"
                    });
                }
                context.Baggages.AddRange(baggages);
                context.SaveChanges();
            }

            // Maintenance data
            if (!context.AircraftMaintenances.Any())
            {
                var aircrafts = context.Aircrafts.ToList();
                var maints = new List<AircraftMaintenance>();
                for (int i = 0; i < 15; i++)
                {
                    var aircraft = aircrafts[rnd.Next(aircrafts.Count)];
                    maints.Add(new AircraftMaintenance
                    {
                        AircraftId = aircraft.AircraftId,
                        MaintenanceDate = DateTime.UtcNow.AddDays(-rnd.Next(0, 90)),
                        Type = rnd.Next(2) == 0 ? "Routine" : "Emergency",
                        Notes = $"Maintenance check {i + 1}"
                    });
                }
                context.AircraftMaintenances.AddRange(maints);
                context.SaveChanges();
            }

        }
    }
}