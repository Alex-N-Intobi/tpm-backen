using AutoMapper;
using IBKS.RestAPI.Base;
using IBKS.Services.Interface;

namespace IBKS.RestAPI.Controllers;

public class LogTypesController : ApiControllerBase<Contracts.LogType, Domains.LogType, ILogTypeService, int>
{
	public LogTypesController(ILogTypeService service,
		IMapper mapper,
		ILogger<InstalledEnvironmentsController> logger)
		: base(service, mapper, logger)
	{
	}
}
