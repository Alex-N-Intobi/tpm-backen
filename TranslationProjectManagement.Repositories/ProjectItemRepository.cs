using TranslationProjectManagement.Domains;
using TranslationProjectManagement.Repositories.Interface;

namespace TranslationProjectManagement.Repositories;

public class ProjectItemRepository : GenericRepository<ProjectItem>, IProjectItemRepository
{
    public ProjectItemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
