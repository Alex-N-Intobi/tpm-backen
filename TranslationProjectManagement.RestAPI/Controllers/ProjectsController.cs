using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranslationProjectManagement.RestAPI.Base;
using TranslationProjectManagement.Services.Interface;

namespace TranslationProjectManagement.RestAPI.Controllers;

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
