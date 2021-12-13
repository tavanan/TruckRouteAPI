using TruckRouteAPI.Models;

namespace TruckRouteAPI.Services.RouteService
{
    public interface IRouteService
    {
          ServiceResponse<Route> GetRouteFromUSA(string code);
          
    }
}