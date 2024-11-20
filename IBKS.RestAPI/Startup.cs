using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using IBKS.Repositories;
using IBKS.Repositories.Base.Interfaces;
using IBKS.RestAPI.Extensions;
using IBKS.Services.Interface;
using IBKS.Services;
using IBKS.RestAPI.Mapping;
using IBKS.Repositories.Interface;

namespace IBKS.RestAPI;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;
    private const string _defaultCorsPolicyName = "IBKSCors";

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpLogging(options =>
        {
            options.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders |
                                    HttpLoggingFields.RequestBody |
                                    HttpLoggingFields.ResponseBody |
                                    HttpLoggingFields.ResponsePropertiesAndHeaders;
        });
       
        services.AddResponseCompression(options =>
        {
            options.Providers.Add<GzipCompressionProvider>();
            options.EnableForHttps = true;
        });

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString(nameof(ApplicationDbContext)));

            ServiceProvider provider = services.BuildServiceProvider();
            IWebHostEnvironment environment = provider.GetRequiredService<IWebHostEnvironment>();
        });

        services.AddSwaggerConfiguration();

        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddPolicy(name: _defaultCorsPolicyName,
                              builder =>
                              {
                                  builder.SetIsOriginAllowed(origin => true)
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowCredentials();
                              });
        });

        services.AddAutoMapperWithDefaultConfiguration(typeof(Startup).Assembly)
            .AddProfileTypes(
            [
                typeof(MappingProfile),
            ]);


        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.RegisterGenericService<IInstalledEnvironmentService, InstalledEnvironmentService, IInstalledEnvironmentRepository, InstalledEnvironmentRepository>();
        services.RegisterGenericService<ILogTypeService, LogTypeService, ILogTypeRepository, LogTypeRepository>();
        services.RegisterGenericService<IPriorityService, PriorityService, IPriorityRepository, PriorityRepository>();
        services.RegisterGenericService<IStatusService, StatusService, IStatusRepository, StatusRepository>();
        services.RegisterGenericService<ITicketEventLogService, TicketEventLogService, ITicketEventLogRepository, TicketEventLogRepository>();
        services.RegisterGenericService<ITicketService, TicketService, ITicketRepository, TicketRepository>();
        services.RegisterGenericService<ITicketTypeService, TicketTypeService, ITicketTypeRepository, TicketTypeRepository>();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(_defaultCorsPolicyName);
        app.UseHttpLogging();

        app.UserSwaggerConfiguration(env);

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}