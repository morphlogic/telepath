using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacSerilogIntegration;
using Morphware.Telepath.Api;
using Morphware.Telepath.DataAccess;
using Serilog;

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{   
    builder.RegisterLogger();
    builder.RegisterModule(new ApiContainerModule());
    builder.RegisterModule(new DataAccessContainerModule(configuration));
});

//builder.RegisterLogger()

builder.Services.AddControllers();
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
