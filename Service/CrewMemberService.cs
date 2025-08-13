using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class CrewMemberService
    {
        private readonly CrewMemberRepository _repo;

        public CrewMemberService(FlightDbContext db)
        {
            _repo = new CrewMemberRepository(db);
        }

        public void CreateSampleCrewMembers()
        {
            if (!_repo.GetAllCrewMembers().Any())
            {
                var crewMembers = new List<CrewMember>
                {
                        new CrewMember { FullName = "John Smith", Role = CrewRole.Pilot, LicenseNumber = "LIC1001" },
                        new CrewMember { FullName = "Alice Brown", Role = CrewRole.CoPilot, LicenseNumber = "LIC2001" },
                        new CrewMember { FullName = "Mark Johnson", Role = CrewRole.FlightAttendant },
                        new CrewMember { FullName = "Sara Davis", Role = CrewRole.FlightAttendant },
                        new CrewMember { FullName = "Tom Wilson", Role = CrewRole.Pilot, LicenseNumber = "LIC1002" },
                        new CrewMember { FullName = "Emma White", Role = CrewRole.CoPilot, LicenseNumber = "LIC2002" },
                        new CrewMember { FullName = "David Clark", Role = CrewRole.FlightAttendant },
                        new CrewMember { FullName = "Olivia Harris", Role = CrewRole.FlightAttendant },
                        new CrewMember { FullName = "James Lewis", Role = CrewRole.Pilot, LicenseNumber = "LIC1003" },
                        new CrewMember { FullName = "Sophia Walker", Role = CrewRole.CoPilot, LicenseNumber = "LIC2003" },
                        new CrewMember { FullName = "Benjamin Hall", Role = CrewRole.FlightAttendant },
                        new CrewMember { FullName = "Mia Allen", Role = CrewRole.FlightAttendant },
                        new CrewMember { FullName = "William Young", Role = CrewRole.Pilot, LicenseNumber = "LIC1004" },
                        new CrewMember { FullName = "Charlotte King", Role = CrewRole.CoPilot, LicenseNumber = "LIC2004" },
                        new CrewMember { FullName = "Henry Wright", Role = CrewRole.FlightAttendant },
                        new CrewMember { FullName = "Amelia Scott", Role = CrewRole.FlightAttendant },
                        new CrewMember { FullName = "Daniel Green", Role = CrewRole.Pilot, LicenseNumber = "LIC1005" },
                        new CrewMember { FullName = "Isabella Baker", Role = CrewRole.CoPilot, LicenseNumber = "LIC2005" },
                        new CrewMember { FullName = "Michael Adams", Role = CrewRole.FlightAttendant },
                        new CrewMember { FullName = "Emily Nelson", Role = CrewRole.FlightAttendant }
                };

                foreach (var crewMember in crewMembers)
                {
                    _repo.AddCrewMember(crewMember);
                }
            }
        }
    }
}