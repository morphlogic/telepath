using Microsoft.AspNetCore.Mvc;
using Morphware.Telepath.Core;
using Morphware.Telepath.Web.Models;

namespace Morphware.Telepath.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        [HttpGet(Name ="GetViewModel")]
        public async Task<DashboardViewModel> GetViewModel()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7296")
            };

            var thinkGroups = await client.GetFromJsonAsync<ICollection<ThinkGroup>>("api/ThinkGroups");

            return new DashboardViewModel
            {
                ThinkGroups = thinkGroups,
            };
        }
    }
}
