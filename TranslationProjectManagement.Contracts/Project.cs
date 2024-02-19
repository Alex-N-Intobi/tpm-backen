using TranslationProjectManagement.Contracts.Base;

namespace TranslationProjectManagement.Contracts;

public class Project : ContractBase
{
    public string Name { get; set; }

    public string Description { get; set; }
    
    public ICollection<ProjectItem> Items { get; set; }
}
