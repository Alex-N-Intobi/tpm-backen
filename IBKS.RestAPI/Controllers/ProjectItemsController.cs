using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using IBKS.RestAPI.Base;
using IBKS.Services.Interface;

namespace IBKS.RestAPI.Controllers;

[Authorize]
public class ProjectItemsController : ApiControllerBase<Contracts.ProjectItem, Domains.ProjectItem, IInstalledEnvironmentService>
{
	public ProjectItemsController(IInstalledEnvironmentService projectItemService,
		IMapper mapper,
		ILogger<ProjectsController> logger)
		: base(projectItemService, mapper, logger)
	{
	}
}
