using AutoMapper;
using System.Reflection;
using IBKS.RestAPI.Mapping.Interfaces;
using IBKS.RestAPI.Mapping;
using IBKS.Repositories.Base.Interfaces;
using IBKS.Services.Base.Interfaces;

namespace IBKS.RestAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IMapperConfigurationBuilder AddAutoMapperWithDefaultConfiguration(this IServiceCollection services, params Assembly[] assemblies)
    {
        var builder = new MapperConfigurationBuilder();

        services.AddSingleton<AutoMapper.IConfigurationProvider>(sp => new MapperConfiguration(cfg =>
        {
            cfg.AllowNullCollections = true;

            foreach (Type profileType in builder.ProfileTypes)
            {
                cfg.AddProfile(profileType);
            }

            if (assemblies?.Any() == true)
            {
                cfg.AddMaps(assemblies);
            }
        }));

        services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

        return builder;
    }

    public static IServiceCollection RegisterGenericService<TIService, TService, TIRepository, TRepository>(this IServiceCollection services)
        where TIService : class, IServiceBase
        where TService : class, TIService
        where TIRepository : class, IRepository
        where TRepository : class, TIRepository
    {
        services.AddScoped<TIService, TService>();
        services.AddScoped<TIRepository, TRepository>();

        return services;
    }
}
