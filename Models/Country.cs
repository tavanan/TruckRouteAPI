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

    }
}