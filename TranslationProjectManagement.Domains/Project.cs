using TranslationProjectManagement.Domains.Base;

namespace TranslationProjectManagement.Domains;

public class Project : DomainBase
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<ProjectItem> Items { get; set; }
}
