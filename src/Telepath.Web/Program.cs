using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutofacSerilogIntegration;
using MassTransit;
using Morphware.Telepath.DataAccess;
using Morphware.Telepath.Messaging;
using Morphware.Telepath.Web;
using Serilog;

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

    builder.RegisterModule(new WebContainerModule());
});

builder.Services.AddMassTransit(x =>
{
    x.ConfigureMassTransit(configuration);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
