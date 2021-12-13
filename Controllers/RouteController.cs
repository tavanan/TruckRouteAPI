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

    }
}