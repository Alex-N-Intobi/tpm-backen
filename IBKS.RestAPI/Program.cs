using IBKS.RestAPI;

var builder = WebApplication.CreateBuilder(args);


var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
