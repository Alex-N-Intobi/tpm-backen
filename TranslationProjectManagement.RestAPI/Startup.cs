using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using TranslationProjectManagement.Domains;
using TranslationProjectManagement.Repositories;
using TranslationProjectManagement.Repositories.Base.Interfaces;
using TranslationProjectManagement.RestAPI.Extensions;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TranslationProjectManagement.Services.Interface;
using TranslationProjectManagement.Services;
using TranslationProjectManagement.RestAPI.Mapping;
using TranslationProjectManagement.Repositories.Interface;
using TranslationProjectManagement.Repositories.Seeders;

namespace TranslationProjectManagement.RestAPI;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;
    private const string _defaultCorsPolicyName = "TranslationProjectManagementCors";

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

        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        })
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = Configuration["Authentication:JwtBearer:Audience"],
                ValidIssuer = Configuration["Authentication:JwtBearer:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:JwtBearer:SecurityKey"]))
            };
        });

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

        services.AddTransient<IIdentityManager, HttpIdentityService>();

        services.AddAutoMapperWithDefaultConfiguration(typeof(Startup).Assembly)
            .AddProfileTypes(
            [
                typeof(MappingProfile),
            ]);


        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.RegisterGenericService<IProjectService, ProjectService, IProjectRepository, ProjectRepository>();
        services.RegisterGenericService<IProjectItemService, ProjectItemService, IProjectItemRepository, ProjectItemRepository>();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(_defaultCorsPolicyName);
        app.UseHttpLogging();

        app.UserSwaggerConfiguration(env);

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.ApplicationServices.Seed();
    }
}