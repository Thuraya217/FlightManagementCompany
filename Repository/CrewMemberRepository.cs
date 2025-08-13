using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public class CrewMemberRepository
    {
        private readonly FlightDbContext _db;

        public CrewMemberRepository(FlightDbContext db)
        {
            _db = db;
        }

        // Add methods for crew member management
        public void AddCrewMember(CrewMember crewMember)
        {
            _db.CrewMembers.Add(crewMember);
            _db.SaveChanges();
        }

        public void UpdateCrewMember(CrewMember crewMember)
        {
            _db.CrewMembers.Update(crewMember);
            _db.SaveChanges();
        }

        public void DeleteCrewMember(int id)
        {
            var crewMember = _db.CrewMembers.Find(id);
            if (crewMember != null)
            {
                _db.CrewMembers.Remove(crewMember);
                _db.SaveChanges();
            }
        }

        public List<CrewMember> GetCrewMembersByRole(CrewRole role)
        {
            return _db.CrewMembers
            .Where(cm => cm.Role == role)
            .ToList();
        }

        public IEnumerable<CrewMember> GetAllCrewMembers() => _db.CrewMembers.ToList();
        public CrewMember GetCrewMemberById(int id) => _db.CrewMembers.Find(id);
    }
}
