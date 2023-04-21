using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var connectionString = _configuration.GetConnectionString("TelepathConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ApplicationException("ConnectionString.TelepathConnection missing from configuration");
            }

            builder.RegisterType<TelepathContext>()
                .WithParameter("connectionString", connectionString)
                .InstancePerLifetimeScope();
        }
    }
}
