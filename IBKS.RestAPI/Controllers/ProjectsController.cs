using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IBKS.RestAPI.Base;
using IBKS.Services.Interface;

namespace IBKS.RestAPI.Controllers;

[Authorize]
public class ProjectsController : ApiControllerBase<Contracts.Project, Domains.Project, IProjectService>
{
	public ProjectsController(IProjectService projectService,
		IMapper mapper,
		ILogger<ProjectsController> logger)
		: base(projectService, mapper, logger)
	{
	}

	[HttpGet]
	[Route("{id}/Items")]
	public async Task<ActionResult<IList<Contracts.ProjectItem>>> GetProjectItems(int id, CancellationToken cancellationToken = default)
	{
		List<Domains.ProjectItem> items = await Service.GetProjectItemsAsync(id, cancellationToken);

		return Mapper.Map<List<Contracts.ProjectItem>>(items);
	}
}
