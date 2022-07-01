using Microsoft.AspNetCore.Mvc;
using Socket.Services;

namespace Socket.Controllers;

[ApiController]
[Route("")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly PusherService _pusherService;
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _pusherService = new PusherService();
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var val = Math.Round(Random.Shared.NextDouble(), 2);
        var res = _pusherService.Trigger("my-channel", "my-event", $"Transferência de R$ {val} recebida");

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
