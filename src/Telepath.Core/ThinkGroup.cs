using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphware.Telepath.Core
{
    public class ThinkGroup
    {
        public ThinkGroup()
        {
            
        }

        public ThinkGroup(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public int ThinkGroupId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();

        public virtual ICollection<Thought> Thoughts { get; set;} = new List<Thought>();
    }
}
