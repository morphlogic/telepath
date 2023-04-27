using Morphware.Telepath.Core;

namespace Morphware.Telepath.Web.Models
{
    public class DashboardViewModel
    {
        public ICollection<ThinkGroup> ThinkGroups { get; set; } = new List<ThinkGroup>();

        public ICollection<Member> Members { get; set; } = new List<Member>();

        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}
