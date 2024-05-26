using Microsoft.AspNetCore.Mvc;
using Service_LifeTime_SingletonScopedTransient.BAL;
using Service_LifeTime_SingletonScopedTransient.IBAL;
using Service_LifeTime_SingletonScopedTransient.Models;

namespace Service_LifeTime_SingletonScopedTransient.Controllers
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
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("PostIceCreams")]
        public IActionResult PostIceCreams([FromServices] IIceCreamsBAL _iceCreamsBAL, IceCream iceCream)
        {
            bool res = _iceCreamsBAL.PostIceCreams(iceCream);
            if (res)
            {
                List<IceCream> icecreams = _iceCreamsBAL.GetIceCreams();
                return Ok(icecreams);
            }
            return BadRequest("Cannot post the data");
        }
    }
}
