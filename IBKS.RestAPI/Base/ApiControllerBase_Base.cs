using AutoMapper;
using IBKS.Services.Base.Interfaces;

namespace IBKS.RestAPI.Base;

public abstract class ApiControllerBase<TIService> : ApiControllerBase where TIService : IServiceBase
{
    public TIService Service { get; }

    public ApiControllerBase(TIService service, IMapper mapper, ILogger<ApiControllerBase> logger) : base(mapper, logger)
    {
        Service = service;
    }
}
