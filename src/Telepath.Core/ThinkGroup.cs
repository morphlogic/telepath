using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphware.Telepath.Core
{
    public class ThinkGroup
    {
        public int ThinkGroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ThinkMember> ThinkMembers { get; set; }
    }
}
