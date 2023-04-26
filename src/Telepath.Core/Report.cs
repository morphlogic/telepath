using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphware.Telepath.Core
{
    public class Report
    {
        public int ReportId { get; set; }

        public int ThinkGroupId { get; set; }

        public int? TopicId { get; set; }

        public ReportStatus Status { get; set; }

        public DateTime Created { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public virtual ICollection<Thought> Thoughts { get; set; }
    }
}
