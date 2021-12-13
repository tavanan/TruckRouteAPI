using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TruckRouteAPI.Models;
using TruckRouteAPI.Services.RouteService;


namespace TruckRouteAPI.Controllers
{
    [ApiController]
    [Route("")]

    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;
        private ILogger _logger;
        public RouteController(IRouteService routeService, ILogger logger)
        {
            _routeService = routeService;
            _logger = logger;
        }


        // Send a Message to the main url to show how to use the api
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
              return Ok(@"To get the Route from USA, add 3 letters CountryCode at the end : 
                          truckrouteapi.azurewebsites.net/{CountryCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            }
            
        }

    }
}