using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacSerilogIntegration;
using MassTransit;
using Morphware.Telepath.Api;
using Morphware.Telepath.DataAccess;
using Morphware.Telepath.Messaging;
using Serilog;
using System.Text.Json.Serialization;

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();

//  TODO:   set up Serilog with proper Sinks
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{   
    builder.RegisterLogger();

    builder.RegisterModule(new DataAccessContainerModule(Log.Logger, configuration));
    builder.RegisterModule(new MessagingContainerModule(Log.Logger, configuration));

    builder.RegisterModule(new ApiContainerModule());
});

builder.Services.AddMassTransit(x =>
{
    x.ConfigureMassTransit(configuration);
});

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
