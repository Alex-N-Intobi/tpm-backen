using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using TranslationProjectManagement.RestAPI.Base;
using TranslationProjectManagement.Services.Interface;

namespace TranslationProjectManagement.RestAPI.Controllers;

[Authorize]
public class ProjectItemsController : ApiControllerBase<Contracts.ProjectItem, Domains.ProjectItem, IProjectItemService>
{
	public ProjectItemsController(IProjectItemService projectItemService,
		IMapper mapper,
		ILogger<ProjectsController> logger)
		: base(projectItemService, mapper, logger)
	{
	}
}
