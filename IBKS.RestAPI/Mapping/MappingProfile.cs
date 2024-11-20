using AutoMapper;

namespace IBKS.RestAPI.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Contracts.InstalledEnvironment, Domains.InstalledEnvironment>()
            .ReverseMap();

        CreateMap<Contracts.LogType, Domains.LogType>()
            .ReverseMap();

        CreateMap<Contracts.Priority, Domains.Priority>()
            .ReverseMap();

        CreateMap<Contracts.Status, Domains.Status>()
            .ReverseMap();

        CreateMap<Contracts.Ticket, Domains.Ticket>()
            .ReverseMap();

        CreateMap<Contracts.TicketReply, Domains.TicketReply>()
            .ReverseMap();

        CreateMap<Contracts.TicketEventLog, Domains.TicketEventLog>()
            .ReverseMap();

        CreateMap<Contracts.TicketType, Domains.TicketType>()
            .ReverseMap();

        CreateMap<Contracts.User, Domains.User>()
            .ReverseMap();
    }
}
