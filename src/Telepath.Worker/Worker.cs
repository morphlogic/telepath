using Morphware.Telepath.DataAccess;
using ILogger = Serilog.ILogger;

namespace Morphware.Telepath.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly TelepathContext _telepathContext;

        public Worker(ILogger logger, TelepathContext telepathContext)
        {
            _logger = logger;
            _telepathContext = telepathContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.Information("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);                
            }
        }
    }
}