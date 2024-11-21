using AutoMapper;
using IBKS.RestAPI.Base;
using IBKS.Services.Interface;

namespace IBKS.RestAPI.Controllers;

public class TicketRepliesController : ApiControllerBase<Contracts.TicketReply, Domains.TicketReply, ITicketReplyService, int>
{
	public TicketRepliesController(ITicketReplyService service,
		IMapper mapper,
		ILogger<TicketRepliesController> logger)
		: base(service, mapper, logger)
	{
	}
}
