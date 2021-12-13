using System.Collections.Generic;
using TruckRouteAPI.Models;

namespace TruckRouteAPI.Services.RouteService
{
    public class RouteService : IRouteService
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

        public ServiceResponse<Route> GetRouteFromUSA(string code)
        {
            var serviceResponse = new ServiceResponse<Route>();
            if(code.Length != 3)
            {
                serviceResponse.Message = "Country code has to be a three-letter acronym, e.g. (USA)!";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            
            // Map of countries
            this.Map();

            
            var route = new Route();
            var path = new List<Country>();

            // Convert input id to upper to accept request with lower case id as well
            string idUpper = code.ToUpper();

            // Find Country with corresponding id
            var destination = countries.Find(country => country.Code == idUpper);
           
            // If country is not found the return proper response
            if (destination == null)
            {
                serviceResponse.Message = "Not found such a destination country";
                serviceResponse.Success = false;
                return serviceResponse;
            }

            // Get path from USA to destination
            path = countries[0].RouteTo(destination);

            // Add each country id to the road path
            foreach (var country in path)
            {
                route.Countries.Add(country.Code);
            }

            route.Destination = destination.Code;
            serviceResponse.Data = route;

            // For our search work properly we make Visited property of every country to false 
            // because we create one service instance and shared across all requests  
            foreach (var country in this.countries)
            {
                country.Visited = false;
            }
            
            // return proper service response
            return serviceResponse;

        }

    }
}