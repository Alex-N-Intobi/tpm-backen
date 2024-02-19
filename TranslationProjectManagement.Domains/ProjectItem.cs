using TranslationProjectManagement.Domains.Base;
using TranslationProjectManagement.Domains.Enums;

namespace TranslationProjectManagement.Domains;

public class ProjectItem : DomainBase
{
    public int ProjectId { get; set; }

    public Project Project { get; set; }

    public int? AssignedUserId { get; set; }
    
    public User AssignedUser { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ProjectItemPriority Priority { get; set; }

    public ProjectItemType Type { get; set; }

    public ProjectItemStatus Status { get; set; }

    public DateTimeOffset? DeliveryDate { get; set; }
}
