using TranslationProjectManagement.Domains;
using TranslationProjectManagement.Repositories.Base.Interfaces;
using TranslationProjectManagement.Repositories.Interface;
using TranslationProjectManagement.Services.Base;
using TranslationProjectManagement.Services.Interface;

namespace TranslationProjectManagement.Services;

public class ProjectService : ServiceBase<Project>, IProjectService
{
    public ProjectService(IProjectRepository projectRepository,
        IUnitOfWork unitOfWork,
        IIdentityManager identityManager) : base(projectRepository, unitOfWork, identityManager)
    {
    }
}
