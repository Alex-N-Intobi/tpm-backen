using IBKS.Domains.Base;

namespace IBKS.Domains;

public class Status : DomainBase<int>
{
    public string Title { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}
