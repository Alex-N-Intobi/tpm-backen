using AutoMapper;
using IBKS.RestAPI.Base;
using IBKS.Services.Interface;

namespace IBKS.RestAPI.Controllers;

public class TicketsController : ApiControllerBase<Contracts.Ticket, Domains.Ticket, ITicketService, long>
{
	public TicketsController(ITicketService service,
		IMapper mapper,
		ILogger<TicketsController> logger)
		: base(service, mapper, logger)
	{
	}
}
