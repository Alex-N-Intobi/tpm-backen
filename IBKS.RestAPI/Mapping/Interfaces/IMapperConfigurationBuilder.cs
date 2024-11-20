namespace IBKS.RestAPI.Mapping.Interfaces;

public interface IMapperConfigurationBuilder
{
    HashSet<Type> ProfileTypes { get; }

    IMapperConfigurationBuilder AddProfileTypes(HashSet<Type> profileTypes);
}
