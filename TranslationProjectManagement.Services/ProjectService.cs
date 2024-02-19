using System;
using System.Linq.Expressions;
using TranslationProjectManagement.Domains;
using TranslationProjectManagement.Repositories.Base.Interfaces;
using TranslationProjectManagement.Repositories.Interface;
using TranslationProjectManagement.Services.Base;
using TranslationProjectManagement.Services.Interface;

namespace TranslationProjectManagement.Services;

public class ProjectService : ServiceBase<Project>, IProjectService
{
    private readonly IProjectRepository _projectRepository;
    public ProjectService(IProjectRepository projectRepository,
        IUnitOfWork unitOfWork,
        IIdentityManager identityManager) : base(projectRepository, unitOfWork, identityManager)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<ProjectItem>> GetProjectItemsAsync(int id, CancellationToken cancellationToken = default)
    {
        Project project =  await _projectRepository.GetOneAsync(id, 
        new Expression<Func<Project, object>>[]
        {
            x=> "Items.AssignedUser",
        },

        cancellationToken);

        return project.Items.ToList();
    }
}
