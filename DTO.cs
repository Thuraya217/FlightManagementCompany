using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany
{
    public class CrewDto
    {
        
        public string CrewName { get; set; }
        public string Role { get; set; } // e.g., Pilot, Flight Attendant
    }

    public class FlightManifestDto
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepUtc { get; set; }
        public DateTime ArrUtc { get; set; }
        public string AircraftTail { get; set; }
        public int PassengerCount { get; set; }
        public decimal TotalBaggageKg { get; set; }
        public List<CrewDto> Crew { get; set; }
    }

    public class RouteRevenueDto
    {
        public int RouteId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Revenue { get; set; }
        public int SeatsSold { get; set; }
        public decimal AvgFare { get; set; }
    }

    public class CrewConflictDto
    {
        public int CrewId { get; set; }
        public string CrewName { get; set; }
        public int FlightAId { get; set; }
        public int FlightBId { get; set; }
        public DateTime FlightADep {  get; set; }
        public DateTime FlightBDep { get; set; }
    }

    public class ItinSegmentDto
    {
        public int FlightId { get; set; }              
        public string FlightNumber { get; set; }       
        public string Origin { get; set; }            
        public string Destination { get; set; }    
        public DateTime DepartureUtc { get; set; }     
        public DateTime ArrivalUtc { get; set; }       
        public string AircraftTail { get; set; }      
    }

    public class PassengerItineraryDto
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public List<ItinSegmentDto> Segments { get; set; }
    }
}
