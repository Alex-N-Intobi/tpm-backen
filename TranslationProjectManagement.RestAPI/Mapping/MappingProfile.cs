using AutoMapper;

namespace TranslationProjectManagement.RestAPI.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Contracts.Project, Domains.Project>()
            .ReverseMap();

        CreateMap<Contracts.ProjectItem, Domains.ProjectItem>()
            .ReverseMap();

        CreateMap<Contracts.User, Domains.User>()
            .ReverseMap();
    }
}
