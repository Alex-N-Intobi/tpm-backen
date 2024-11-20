using IBKS.Domains.Base;

namespace IBKS.Domains;

public class Priority : DomainBase<int>
{
    public string Title { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}
