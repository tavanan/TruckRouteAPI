using System.Collections.Generic;

namespace TruckRouteAPI.Models
{
    public class Country
    {
        /// <summary>
        /// Code of the Country 
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Check if the node is visited used in BFS algorithm
        /// </summary>
        public bool Visited { get; set; } = false;

        /// <summary>
        /// List of neighbouring countries
        /// </summary>
        public List<Country> Neighbours { get; set; } = new List<Country>();

        /// <summary>
        /// Getting track of previous country in BFS algorithm
        /// </summary>
        private Country Preceding { get; set; } = null;

        public Country(string code)
        {
            this.Code = code;
        }

        /// <summary>
        /// Adding neighbouring countries
        /// </summary>
        /// <param name="neighbours">params neighbours</param>
        public void AddNeighbours(params Country[] neighbours)
        {
            // If no argument then just return
            if (neighbours.Length == 0)
            {
                return;
            }
            
            // Add neighbours to each other
            foreach (var neighbour in neighbours)
            {
                this.Neighbours.Add(neighbour);
                neighbour.Neighbours.Add(this);
            }
        }

        /// <summary>
        /// Extracting the route from destination and reverse it to get actual route.
        /// </summary>
        /// <param name="destination">Destination country.</param>
        /// <returns>returning route as a list of countries.</returns>
        private List<Country> ExtractRoute(Country destination)
        {

            var route = new List<Country>();

            // Iterate until Country is null to reach source Country 
            // because Preceding node of source is null
            while (destination != null)
            {
                route.Add(destination);
                destination = destination.Preceding;
            }

            //Reverse the to get route from source to destination
            route.Reverse();
            return route;
        }

        /// <summary>
        /// Pass a destination Country and it returns the route to that.
        /// </summary>
        /// <param name="destination"> destination Country</param>
        /// <returns>List of countries from this country as source.</returns>
        public List<Country> RouteTo(Country destination)
        {
            // Initialize Queue
            var queue = new Queue<Country>();
            
            // Visit and push the source Country to the queue
            this.Visited = true;
            queue.Enqueue(this);

            // BFS algorithm until queue is not empty and not reached to the destination Country
            while (queue.Count != 0)
            {
                // Pop a node from the queue
                Country currentCountry = queue.Dequeue();

                // Search through neighbours countries to find the destination
                foreach (var country in currentCountry.Neighbours)
                {
                    // Check if Country is already visited
                    if (!country.Visited)
                    {
                        // Visit and push the Country to the queue 
                        country.Visited = true;
                        queue.Enqueue(country);

                        // Update its preceding Country
                        country.Preceding = currentCountry;

                        // If reached to the destination then stop the search
                        if (country == destination)
                        {
                            queue.Clear();
                            break;
                        }
                    }
                }
            }
            // Extracting the route from the results
            return ExtractRoute(destination);
        }

    }
    
}