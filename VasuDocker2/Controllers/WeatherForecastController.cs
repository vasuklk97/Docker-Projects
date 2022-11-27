using Microsoft.AspNetCore.Mvc;
using VasuDocker.Controllers;

namespace VasuDocker2.Controllers
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

        Student student = new Student();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api")]
        public IEnumerable<WeatherForecast1> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast1
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("test")]
        public string Test()
        {
            student.FirstName = "Vasu";
            student.LastName = "Kulkarni";
            return student.GetFullName();
        }
    }
}