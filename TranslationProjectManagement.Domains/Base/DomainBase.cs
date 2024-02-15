using System.ComponentModel.DataAnnotations;

namespace TranslationProjectManagement.Domains.Base;

public abstract class DomainBase
{
    public int Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public int CreatedById { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public int? ModifiedById { get; set; }

    [Timestamp]
    public byte[] Timestamp { get; set; }
}
