using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using usoftware_mp_lib.Model;

namespace uSoftware_mp_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Usuarios
            {
                ID = rng.Next(-20, 55),
                Nome = "TESTE FOI",
                Login = "TESTE FOI"
            })
            .ToArray();
        }
    }
}
