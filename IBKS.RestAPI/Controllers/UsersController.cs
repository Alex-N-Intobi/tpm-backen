using AutoMapper;
using IBKS.RestAPI.Base;
using IBKS.Services.Interface;

namespace IBKS.RestAPI.Controllers;

public class UsersController : ApiControllerBase<Contracts.User, Domains.User, IUserService, string>
{
	public UsersController(IUserService service,
		IMapper mapper,
		ILogger<UsersController> logger)
		: base(service, mapper, logger)
	{
	}
}
