using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Morphware.Telepath.Core;
using Morphware.Telepath.Web;
using Morphware.Telepath.Web.Models;
using System.Diagnostics;

namespace Morphware.Telepath.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly IEnumerable<EndpointDataSource> _endpointSources;

    public WeatherForecastController(IEnumerable<EndpointDataSource> endpointSources)
    {
        _endpointSources = endpointSources;
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

        var endpoints = _endpointSources
            .SelectMany(s => s.Endpoints)
            .OfType<RouteEndpoint>();

        var output = endpoints.Select(e =>
        {
            var controller = e.Metadata
            .OfType<ControllerActionDescriptor>()
            .FirstOrDefault();

            var action = controller != null
            ? $"{controller.ControllerName}.{controller.ActionName}"
            : null;

            var controllerMethod = controller != null
            ? $"{controller.ControllerTypeInfo.FullName}:{controller.MethodInfo.Name}"
            : null;

            return new
            {
                Method = e.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods?[0],
                Route = $"/{e.RoutePattern.RawText?.TrimStart('/')}",
                Action = action,
                ControllerMethod = controllerMethod
            };
        });

        Debugger.Log(0, "INFO", $"{string.Join($"; {Environment.NewLine}",
            output.Select(e => $"{e.Method},{e.Route},{e.Action},{e.ControllerMethod}"))}{Environment.NewLine}{Environment.NewLine}");

        //

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
