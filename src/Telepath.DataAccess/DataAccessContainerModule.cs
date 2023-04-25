using Autofac;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Morphware.Telepath.DataAccess
{
    public class DataAccessContainerModule : Module
    {
        private readonly ILogger _logger;
        private readonly IConfigurationRoot _configuration;

        public DataAccessContainerModule(ILogger logger, IConfigurationRoot configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("Telepath");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ApplicationException("ConnectionStrings.Telepath missing from configuration");
                }

                builder.RegisterType<TelepathContext>()
                    .WithParameter("connectionString", connectionString)
                    .InstancePerLifetimeScope();
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "DataAccessContainerModule failed to Load(..)");

                throw;
            }            
        }
    }
}
