using System.Collections.Generic;
using TruckRouteAPI.Models;

namespace TruckRouteAPI.Services.RouteService
{
    public class RouteService
    {
        private readonly List<Country> countries = new List<Country>()
        {
            new Country("USA"),
            new Country("CAN"),
            new Country("MEX"),
            new Country("BLZ"),
            new Country("GTM"),
            new Country("SLV"),
            new Country("HND"),
            new Country("NIC"),
            new Country("CRI"),
            new Country("PAN")
        };

    }
}