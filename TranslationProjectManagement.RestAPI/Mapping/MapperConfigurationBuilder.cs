using TranslationProjectManagement.RestAPI.Mapping.Interfaces;

namespace TranslationProjectManagement.RestAPI.Mapping;

public class MapperConfigurationBuilder : IMapperConfigurationBuilder
{
    public HashSet<Type> ProfileTypes { get; } = new HashSet<Type>();

    public IMapperConfigurationBuilder AddProfileTypes(HashSet<Type> profileTypes)
    {
        if (profileTypes == null)
        {
            return this;
        }

        foreach (Type profileType in profileTypes)
        {
            ProfileTypes.Add(profileType);
        }

        return this;
    }
}
