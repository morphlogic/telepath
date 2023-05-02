using Microsoft.AspNetCore.Mvc;
using Morphware.Telepath.Core;
using Morphware.Telepath.Web.Models;
using System.Diagnostics;

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

            var thinkGroupsTask = client.GetFromJsonAsync<ICollection<ThinkGroup>>("api/ThinkGroups");

            var membersTask = client.GetFromJsonAsync<ICollection<Member>>("api/Members");

            var topicsTask = client.GetFromJsonAsync<ICollection<Topic>>("api/Topics");

            Task.WaitAll(thinkGroupsTask, membersTask, topicsTask);

            Debug.Assert(thinkGroupsTask.Result != null);
            Debug.Assert(membersTask.Result != null);
            Debug.Assert(topicsTask.Result != null);

            return new DashboardViewModel
            {
                ThinkGroups = thinkGroupsTask.Result,
                Members = membersTask.Result,
                Topics = topicsTask.Result
            };
        }
    }
}
