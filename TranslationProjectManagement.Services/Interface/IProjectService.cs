using TranslationProjectManagement.Domains;
using TranslationProjectManagement.Services.Base.Interfaces;

namespace TranslationProjectManagement.Services.Interface;

public interface IProjectService: IServiceBase<Project>
{
    Task<List<ProjectItem>> GetProjectItemsAsync(int id, CancellationToken cancellationToken = default);
}
