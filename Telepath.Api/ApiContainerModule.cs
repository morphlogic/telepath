﻿using Autofac;
using Morphware.Telepath.DataAccess;

namespace Morphware.Telepath.Api
{
    internal class ApiContainerModule : Module
    {
        private readonly IConfiguration _configuration;

        public ApiContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = _configuration.GetConnectionString("TelepathConnection");

            if(string.IsNullOrEmpty(connectionString))
            {
                throw new ApplicationException("ConnectionStrings.TelepathConnection missing from appsettings.json");
            }

            builder.RegisterType<TelepathContext>()
                .WithParameter("connectionString", connectionString)
                .InstancePerLifetimeScope();
        }
    }
}