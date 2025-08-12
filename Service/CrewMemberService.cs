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
    }
}