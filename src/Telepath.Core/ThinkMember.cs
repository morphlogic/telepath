using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphware.Telepath.Core
{
    public class ThinkMember
    {
        public int ThinkMemberId { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<ThinkGroup> ThinkGroups { get; set; }
    }
}
