using AutoMapper;
using IBKS.RestAPI.Base;
using IBKS.Services.Interface;

namespace IBKS.RestAPI.Controllers;

public class TicketTypesController : ApiControllerBase<Contracts.TicketType, Domains.TicketType, ITicketTypeService, int>
{
	public TicketTypesController(ITicketTypeService service,
		IMapper mapper,
		ILogger<TicketTypesController> logger)
		: base(service, mapper, logger)
	{
	}
}
