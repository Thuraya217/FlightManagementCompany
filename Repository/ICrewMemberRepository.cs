using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface ICrewMemberRepository
    {
        void AddCrewMember(CrewMember crewMember);
        void DeleteCrewMember(int id);
        IEnumerable<CrewMember> GetAllCrewMembers();
        CrewMember GetCrewMemberById(int id);
        List<CrewMember> GetCrewMembersByRole(CrewRole role);
        void UpdateCrewMember(CrewMember crewMember);
    }
}