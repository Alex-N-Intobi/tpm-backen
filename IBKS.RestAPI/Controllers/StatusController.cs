using AutoMapper;
using IBKS.RestAPI.Base;
using IBKS.Services.Interface;

namespace IBKS.RestAPI.Controllers;

public class StatusesController : ApiControllerBase<Contracts.Status, Domains.Status, IStatusService, int>
{
	public StatusesController(IStatusService service,
		IMapper mapper,
		ILogger<StatusesController> logger)
		: base(service, mapper, logger)
	{
	}
}
