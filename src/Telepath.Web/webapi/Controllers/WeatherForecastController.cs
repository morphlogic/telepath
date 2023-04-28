using Microsoft.AspNetCore.Mvc;
using Morphware.Telepath.Core;
using Morphware.Telepath.Web;
using Morphware.Telepath.Web.Models;

namespace Morphware.Telepath.Web.Controllers;

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
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        //var client = new HttpClient
        //{
        //    BaseAddress=new Uri("https://localhost:7296")
        //};

        //await client.PostAsJsonAsync("api/ThinkGroups", new ThinkGroup("Group" + DateTime.Now.Ticks.ToString(), "Another group"));

        //var viewModel = await GetViewModel();

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();        
    }        
}
