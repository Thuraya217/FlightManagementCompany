using FlightManagementCompany.Models;
using FlightManagementCompany.Service;
using System.Collections.Generic;

namespace FlightManagementCompany
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Ensure the database is created
            using FlightDbContext db = new FlightDbContext();
            db.Database.EnsureCreated();

            // Initialize the database with seed data
            SeedData.Initialize(db);

            // Initialize services
            AircraftService AS = new AircraftService(db);
            AircraftMaintenanceService AM = new AircraftMaintenanceService(db);
            PassengerService PS = new PassengerService(db);
            FlightCrewService FCS = new FlightCrewService(db);
            BookingService BS = new BookingService(db);
            AirportService ARS = new AirportService(db);
            FlightService FS = new FlightService(db);
            BaggageService BGS = new BaggageService(db);
            CrewMemberService CMS = new CrewMemberService(db);
            RouteService RS = new RouteService(db);
            TicketService TS = new TicketService(db);

            // Create sample data
            //AS.CreateSampleAircrafts();
            //AM.CreateSampleAircraftMaintenances();
            //PS.CreateSamplePassengers();
            //FCS.CreateSampleFlightCrews();
            //BS.CreateSampleBookings();
            //ARS.CreateSampleAirports();
            //FS.CreateSampleFlights();
            //BGS.CreateSampleBaggages();
            //CMS.CreateSampleCrewMembers();
            //RS.CreateSampleRoutes();
            //TS.CreateSampleTickets();



        }
    }
}
