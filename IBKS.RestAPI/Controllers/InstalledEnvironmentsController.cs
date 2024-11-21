using AutoMapper;
using IBKS.RestAPI.Base;
using IBKS.Services.Interface;

namespace IBKS.RestAPI.Controllers;

public class InstalledEnvironmentsController : ApiControllerBase<Contracts.InstalledEnvironment, Domains.InstalledEnvironment, IInstalledEnvironmentService, int>
{
	public InstalledEnvironmentsController(IInstalledEnvironmentService service,
		IMapper mapper,
		ILogger<InstalledEnvironmentsController> logger)
		: base(service, mapper, logger)
	{
	}
}
