using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace IBKS.RestAPI.Base;

[ApiController]
[Produces("application/json")]
[Route("/api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    public IMapper Mapper { get; }

    public ILogger<ApiControllerBase> Logger { get; }

    public ApiControllerBase(IMapper mapper, ILogger<ApiControllerBase> logger)
    {
        Mapper = mapper;
        Logger = logger;
    }

    protected ObjectResult Problem(string type, string title, string detail)
    {
        return Problem(detail, HttpContext.Request.Path, StatusCodes.Status400BadRequest, title, type);
    }
}
