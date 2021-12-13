

namespace TruckRouteAPI.Models
{
    ///<remarks>Using for giving proper message response</remarks>
    public class ServiceResponse<T>
    {
        /// <summary>
        /// Generic data type for returning data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// bool value to show if the request is successfull
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Returning a message to the client
        /// </summary>
        public string Message { get; set; } = null;
    }
}