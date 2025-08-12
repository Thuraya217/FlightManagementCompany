using FlightManagementCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementCompany
{
    public class FlightDbContext : DbContext
    {
        public DbSet <Aircraft> Aircrafts { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CrewMember> CrewMembers { get; set; }
        public DbSet<FlightCrew> FlightCrews { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<AircraftMaintenance> AircraftMaintenances { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Baggage> Baggages { get; set; }
        public DbSet<Passenger> Passengers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=FlightManagement;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            // one to meny tables
            modelBuilder.Entity<Flight>()
                .HasOne(F => F.Route)
                .WithMany(A => A.Flights)
                .HasForeignKey(F => F.RouteId);

            modelBuilder.Entity<Flight>()
                .HasOne(F => F.Aircraft)
                .WithMany(A => A.Flights)
                .HasForeignKey(F => F.AircraftId);

            modelBuilder.Entity<Booking>()
                .HasOne(B => B.Passenger)
                .WithMany(P => P.Bookings)
                .HasForeignKey(B => B.PassengerId);

            modelBuilder.Entity<Ticket>()
                .HasOne(T => T.Booking)
                .WithMany(B => B.Tickets)
                .HasForeignKey(T => T.BookingId);

            modelBuilder.Entity<Ticket>()
                .HasOne(T => T.Flight)
                .WithMany(F => F.Tickets)
                .HasForeignKey(T => T.FlightId);

            modelBuilder.Entity<Baggage>()
                .HasOne(B => B.Ticket)
                .WithMany(T => T.Baggages)
                .HasForeignKey(B => B.TicketId);

            modelBuilder.Entity<AircraftMaintenance>()
                .HasOne(AM => AM.Aircraft)
                .WithMany(A => A.AircraftMaintenances)
                .HasForeignKey(AM => AM.AircraftId);

            // meny to meny table
            modelBuilder.Entity<FlightCrew>()
                .HasKey(fc => new { fc.FlightId, fc.CrewId });

            modelBuilder.Entity<FlightCrew>()
                .HasOne(fc => fc.Flight)
                .WithMany(f => f.FlightCrews)
                .HasForeignKey(fc => fc.FlightId);

            modelBuilder.Entity<FlightCrew>()
                .HasOne(fc => fc.CrewMember)
                .WithMany(c => c.FlightCrews)
                .HasForeignKey(fc => fc.CrewId);

            // table have two foreign keys
            modelBuilder.Entity<Route>()
                .HasOne(t => t.OriginAirport)
                .WithMany(f => f.OriginRoutes)
                .HasForeignKey(t => t.OriginAirportId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete to prevent cascading deletes

            modelBuilder.Entity<Route>()
                .HasOne(t => t.DestinationAirport)
                .WithMany(b => b.DestinationRoutes)
                .HasForeignKey(t => t.DestinationAirportId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete to prevent cascading deletes

            // Add unique index on Airport IATA code
            modelBuilder.Entity<Airport>()
                .HasIndex(a => a.IATA)
                .IsUnique();

            // Add unique index on Aircraft TailNumber
            modelBuilder.Entity<Aircraft>()
                .HasIndex(a => a.TailNumber)
                .IsUnique();

            // Add unique index on Passenger PassportNo
            modelBuilder.Entity<Passenger>()
                   .HasIndex(p => p.PassportNumber)
                   .IsUnique();

            // Add unique index on Booking BookingRef
            modelBuilder.Entity<Booking>()
                .HasIndex(p => p.BookingRef)
                .IsUnique();
        }
    }
}