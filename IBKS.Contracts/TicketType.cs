using IBKS.Contracts.Base;

namespace IBKS.Contracts;

public class TicketType : ContractBase<int>
{
    public string Title { get; set; }
}
