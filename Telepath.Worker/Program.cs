using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacSerilogIntegration;
using Morphware.Telepath.Worker;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = Host.CreateDefaultBuilder(args);

builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterLogger();
    builder.RegisterModule(new WorkerContainerModule());
});

IHost host = builder
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
