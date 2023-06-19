using Microsoft.AspNetCore.Mvc;
using SOLID_DependencyInjection_0506_v2.Services;

namespace SOLID_DependencyInjection_0506_v2.Controllers
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
        private readonly IMessageWriter _messageWriter;
        private readonly IWorker _worker;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IMessageWriter messageWriter,
            IWorker worker
            )
        {
            _logger = logger;
            _messageWriter = messageWriter;
            _worker = worker;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //var msgWriter = new MessageWriter();

            //var worker = new Worker(_messageWriter);

            //worker.DoWork();

            _worker.DoWork();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}