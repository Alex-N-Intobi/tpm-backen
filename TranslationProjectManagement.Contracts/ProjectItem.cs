using TranslationProjectManagement.Contracts.Base;

namespace TranslationProjectManagement.Contracts;

public class ProjectItem : ContractBase
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Type { get; set; }

    public string Status { get; set; }

    public DateTimeOffset DeliveryDate { get; set; }

    public int? AssignedUserId { get; set; }

    public User AssignedUser { get; set; }
}
