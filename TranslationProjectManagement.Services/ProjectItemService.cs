using TranslationProjectManagement.Domains;
using TranslationProjectManagement.Repositories.Base.Interfaces;
using TranslationProjectManagement.Repositories.Interface;
using TranslationProjectManagement.Services.Base;
using TranslationProjectManagement.Services.Interface;

namespace TranslationProjectManagement.Services;

public class ProjectItemService : ServiceBase<ProjectItem>, IProjectItemService
{
    public ProjectItemService(IProjectItemRepository projectItemRepository,
        IUnitOfWork unitOfWork,
        IIdentityManager identityManager) : base(projectItemRepository, unitOfWork, identityManager)
    {
    }
}
