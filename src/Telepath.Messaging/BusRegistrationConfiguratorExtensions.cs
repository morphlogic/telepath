using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphware.Telepath.Messaging
{
    public static class BusRegistrationConfiguratorExtensions
    {
        public static void ConfigureMassTransit(this IBusRegistrationConfigurator registrationConfigurator, IConfigurationRoot configuration)
        {
            var messagingConfiguration = new MessagingConfigurationSection(configuration, Constants.Messaging);

            if(messagingConfiguration.Type == MessagingType.InMemory)
            {
                registrationConfigurator.UsingInMemory((context, factoryConfigurator) =>
                {
                    //  TODO:   configure in-memory queue

                    factoryConfigurator.ConfigureEndpoints(context);
                });
            }
            else if(messagingConfiguration.Type == MessagingType.RabbitMQ)
            {
                registrationConfigurator.UsingRabbitMq((context, factoryConfigurator) =>
                {
                    factoryConfigurator.Host(messagingConfiguration.Host, "/", hostConfigurator =>
                    {
                        hostConfigurator.Username(messagingConfiguration.Username);
                        hostConfigurator.Password(messagingConfiguration.Password);
                    });

                    factoryConfigurator.ConfigureEndpoints(context);
                });
            }
        }
    }
}
