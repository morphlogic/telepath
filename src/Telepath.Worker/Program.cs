using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacSerilogIntegration;
using MassTransit;
using Morphware.Telepath.DataAccess;
using Morphware.Telepath.Messaging;
using Morphware.Telepath.Worker;
using Serilog;

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();

//  TODO:   set up Serilog with proper Sinks
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = Host.CreateDefaultBuilder(args);

builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterLogger();

    builder.RegisterModule(new DataAccessContainerModule(Log.Logger, configuration));
    builder.RegisterModule(new MessagingContainerModule(Log.Logger, configuration));

    builder.RegisterModule(new WorkerContainerModule());
});

IHost host = builder
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
        {
            x.ConfigureMassTransit(configuration);
        });

        services.AddHostedService<Worker>();        
    })
    .Build();

await host.RunAsync();
