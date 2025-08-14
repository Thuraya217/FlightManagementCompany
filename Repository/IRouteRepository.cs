using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IRouteRepository
    {
        void AddRoute(Route route);
        void DeleteRoute(int id);
        IEnumerable<Route> GetAllRoutes();
        Route GetRouteById(int id);
        void UpdateRoute(Route route);
    }
}