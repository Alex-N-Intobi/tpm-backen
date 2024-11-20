using IBKS.Contracts.Base;

namespace IBKS.Contracts;

public class Priority : ContractBase<int>
{

    public string Title { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}
