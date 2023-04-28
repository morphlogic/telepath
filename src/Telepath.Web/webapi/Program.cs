var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//using Autofac;
//using Autofac.Core;
//using Autofac.Extensions.DependencyInjection;
//using AutofacSerilogIntegration;
//using Morphware.Telepath.Web;
////using MassTransit;
////using Morphware.Telepath.DataAccess;
////using Morphware.Telepath.Messaging;
//using Serilog;

//var configurationBuilder = new ConfigurationBuilder();
//configurationBuilder.AddJsonFile("appsettings.json");

//var configuration = configurationBuilder.Build();

////  TODO:   set up Serilog with proper Sinks
//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .CreateLogger();

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
//{
//    builder.RegisterLogger();

//    //builder.RegisterModule(new DataAccessContainerModule(Log.Logger, configuration));
//    //builder.RegisterModule(new MessagingContainerModule(Log.Logger, configuration));

//    builder.RegisterModule(new WebContainerModule());
//});

////builder.Services.AddMassTransit(x =>
////{
////    x.ConfigureMassTransit(configuration);
////});

//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    //app.UseExceptionHandler("/Home/Error");
//    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    //app.UseHsts();

//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//else
//{
//    app.UseDefaultFiles();
//    app.UseStaticFiles();
//}

//app.UseHttpsRedirection();
////app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllers();

////app.MapControllerRoute(
////    name: "default",
////    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();

////var builder = WebApplication.CreateBuilder(args);

////// Add services to the container.

////builder.Services.AddControllers();
////// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

////var app = builder.Build();

////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseHttpsRedirection();

////app.UseAuthorization();

////app.MapControllers();

////app.Run();
