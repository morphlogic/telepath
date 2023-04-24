using Autofac;
using Microsoft.Extensions.Configuration;

namespace Morphware.Telepath.DataAccess
{
    public class DataAccessContainerModule : Module
    {
        private readonly IConfiguration _configuration;

        public DataAccessContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
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
    }
}
