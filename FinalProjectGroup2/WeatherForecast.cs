using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace FinalProjectGroup2
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController :
ControllerBase
    {
        //I believe I added some sort of possible example in here
        private static readonly string[] Summaries = new[]
        {
"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
        private readonly ILogger _logger;
        public WeatherForecastController(ILogger logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });.ToArray();
        }
    }
}
