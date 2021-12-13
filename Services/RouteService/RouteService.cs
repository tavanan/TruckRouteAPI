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
        
        /// <summary>
        /// Add neighbours to the countries to make a map
        /// </summary>
        private void Map()
        {
            
            countries[0].AddNeighbours(countries[1], countries[2]);
            countries[2].AddNeighbours(countries[3], countries[4]);
            countries[3].AddNeighbours(countries[4]);
            countries[4].AddNeighbours(countries[5], countries[6]);
            countries[5].AddNeighbours(countries[6]);
            countries[6].AddNeighbours(countries[7]);
            countries[7].AddNeighbours(countries[8]);
            countries[8].AddNeighbours(countries[9]);

        }

    }
}