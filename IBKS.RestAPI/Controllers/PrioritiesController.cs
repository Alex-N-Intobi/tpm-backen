using AutoMapper;
using IBKS.RestAPI.Base;
using IBKS.Services.Interface;

namespace IBKS.RestAPI.Controllers;

public class PrioritiesController : ApiControllerBase<Contracts.Priority, Domains.Priority, IPriorityService, int>
{
	public PrioritiesController(IPriorityService service,
		IMapper mapper,
		ILogger<PrioritiesController> logger)
		: base(service, mapper, logger)
	{
	}
}
