using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TranslationProjectManagement.RestAPI.Base;
using TranslationProjectManagement.Services.Dtos;
using TranslationProjectManagement.Services.Interface;

namespace TranslationProjectManagement.RestAPI.Controllers;

public class UsersController : ApiControllerBase<IUserService>
{
    public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> logger)
        : base(userService, mapper, logger) 
    {
    }

    [HttpGet]
    [Route("lookups/{role}")]
    public async Task<ActionResult<List<LookupFieldDto>>> GetLookups(string role, CancellationToken cancellationToken = default)
    {
        IList<LookupFieldDto> lookups = await Service.GetLookupFieldsAsync(role, cancellationToken);
        return Ok(lookups);
    }
}
