using MassTransit;
using Morphware.Telepath.DataAccess;
using Morphware.Telepath.Messaging;
using ILogger = Serilog.ILogger;

namespace Morphware.Telepath.Worker.Consumers
{
    internal class GenerateReportConsumer : IConsumer<GenerateReport>
    {
        private readonly ILogger _logger;
        private readonly TelepathContext _context;

        public GenerateReportConsumer(ILogger logger, TelepathContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Consume(ConsumeContext<GenerateReport> context)
        {
            var report = _context.Reports.Single(r => r.ReportId == context.Message.ReportId);

            report.Status = Core.ReportStatus.Processing;            

            await _context.SaveChangesAsync();

            _logger.Information("Processing Report {ReportId}", report.ReportId);
        }
    }
}
