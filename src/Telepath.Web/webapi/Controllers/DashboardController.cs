using Microsoft.AspNetCore.Mvc;
using Morphware.Telepath.Core;
using Morphware.Telepath.Web.Models;

namespace Morphware.Telepath.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        [HttpGet(Name ="GetDashboard")]
        public async Task<DashboardViewModel> Get()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7296")
            };

            var thinkGroups = await client.GetFromJsonAsync<ICollection<ThinkGroup>>("api/ThinkGroups");

            var members = await client.GetFromJsonAsync<ICollection<Member>>("api/Members");

            var topics = await client.GetFromJsonAsync<ICollection<Topic>>("api/Topics");

            return new DashboardViewModel
            {
                ThinkGroups = thinkGroups,
                Members = members,
                Topics = topics
            };
        }
    }
}
