using Autofac;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Morphware.Telepath.Messaging
{
    public class MessagingContainerModule : Module
    {
        private readonly ILogger _logger;
        private readonly IConfigurationRoot _configuration;

        public MessagingContainerModule(ILogger logger, IConfigurationRoot configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {            
        }
    }
}
