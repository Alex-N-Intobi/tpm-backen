using TranslationProjectManagement.Domains;
using TranslationProjectManagement.Repositories.Interface;

namespace TranslationProjectManagement.Repositories;

public class ProjectRepository: GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
