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
    public class CrewMemberService
    {
        private readonly CrewMemberRepository _crewRepo;

        public CrewMemberService(FlightDbContext db)
        {
            _crewRepo = new CrewMemberRepository(db);
        }

        public IEnumerable<CrewConflictDto> DetectCrewConflicts()
        {
            var conflicts = new List<CrewConflictDto>();

            var crews = _crewRepo.GetAllWithFlights(); 

            foreach (var crew in crews)
            {
                var flights = crew.FlightCrews.Select(fc => fc.Flight)
                                .OrderBy(f => f.DepartureUtc)
                                .ToList();

                for (int i = 0; i < flights.Count; i++)
                {
                    for (int j = i + 1; j < flights.Count; j++)
                    {
                        if (flights[i].ArrivalUtc > flights[j].DepartureUtc)
                        {
                            conflicts.Add(new CrewConflictDto
                            {
                                CrewId = crew.CrewId,
                                CrewName = crew.FullName,
                                FlightAId = flights[i].FlightId,
                                FlightBId = flights[j].FlightId,
                                FlightADep = flights[i].DepartureUtc,
                                FlightBDep = flights[j].DepartureUtc
                            });
                        }
                    }
                }
            }
            return conflicts;
        }
    }
}
