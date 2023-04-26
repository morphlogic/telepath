using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphware.Telepath.Messaging
{
    public record GenerateReport
    {
        public int ReportId { get; init; }

        public GenerateReport(int reportId)
        {
            ReportId = reportId;
        }
    }
}
