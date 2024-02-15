using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
}
