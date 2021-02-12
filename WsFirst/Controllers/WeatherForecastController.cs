using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WsFirst.Services;

namespace WsFirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        private static readonly string[] Towns = new[]
        {
            "Thann", "Mulhouse", "Colmar"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            Response.Headers.Add("testsf","valeurtest123");

            CookieActions cookie = new CookieActions{
                response = Response,
                request = Request
            };

            cookie.SetCookie("testcookie","testvaluecookie",60);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Town = Towns[rng.Next(Towns.Length)]
            })
            .ToArray();
        }


        [HttpGet("{id}")]
        public WeatherForecast GetOne(long id)
        {
            
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Town = Towns[rng.Next(Towns.Length)]
            };
        }
    }

    
}
