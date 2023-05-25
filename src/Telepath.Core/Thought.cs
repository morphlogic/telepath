using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphware.Telepath.Core
{
    public class Thought
    {
        public int ThoughtId { get; set; }

        public int ThinkGroupId { get; set; }

        public int MemberId { get; set; }

        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }

        public DateTime Occurred { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        public virtual ThinkGroup? ThinkGroup { get; set; }

        public virtual Member Member { get; set; }        
    }
}
