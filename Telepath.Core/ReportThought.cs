using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphware.Telepath.Core
{
    public class ReportThought
    {
        [Key, Column(Order = 0)]
        public int ReportId { get; set; }

        [Key, Column(Order = 1)]
        public int ThoughtId { get; set; }

        public Report Report { get; set; }

        public Thought Thought { get; set; }
    }
}
