using IBKS.Domains.Base;

namespace IBKS.Domains;

public class User : DomainBase<string>
{
    public string DisplayName { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public DateTime? LastScannedUtc { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}
