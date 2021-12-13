using System.Collections.Generic;

namespace TruckRouteAPI.Models
{
    ///<remarks>Hold data for response</remarks>
    public class Route
    {
        ///<summary>
        /// Destination Country code
        /// </summary> 
        public string Destination { get; set; } = null;

        /// <summary>
        /// Countries on route to the destination
        /// </summary>
        public List<string> Countries { get; set; } = new List<string>();
        
    }
}