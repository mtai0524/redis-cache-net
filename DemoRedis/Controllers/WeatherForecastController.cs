using DemoRedis.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace DemoRedis.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        [Cache(1000)]
        public async Task<IActionResult> GetAsync(string keyword, int pageIndex, int pageSize)
        {
            var result = new List<WeatherForecast>()
            {
                new WeatherForecast () {Name = "minhtai"},
                new WeatherForecast () {Name = "minhtai2"},
                new WeatherForecast () {Name = "minhtai3"},
            };

            return Ok(result);
        }
    }
}
