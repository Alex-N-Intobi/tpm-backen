using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TranslationProjectManagement.RestAPI.Base;
using TranslationProjectManagement.Services.Dtos.Requests;
using TranslationProjectManagement.Services.Dtos.Responses;
using TranslationProjectManagement.Services.Interface;

namespace TranslationProjectManagement.RestAPI.Controllers;

public class AuthenticateController : ApiControllerBase<IUserService>
{
    public AuthenticateController(IUserService userService, IMapper mapper, ILogger<AuthenticateController> logger)
        : base(userService, mapper, logger) 
    {
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<TokenResponse>> Login([FromBody]LoginRequest request, CancellationToken cancellationToken = default)
    {
        TokenResponse tokenResponse = await Service.LoginAsync(request, cancellationToken);
        return Ok(tokenResponse);
    }

    [HttpGet]
    [Route("current/user")]
    public async Task<ActionResult<Contracts.User>> GetCurrentUser(CancellationToken cancellationToken = default)
    {
        Domains.User user = await Service.GetCurrentUser(cancellationToken);
        return Ok(Mapper.Map<Contracts.User>(user));
    }
}
