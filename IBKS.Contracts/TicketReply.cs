using IBKS.Contracts.Base;

namespace IBKS.Contracts;

public class TicketReply: ContractBase<int>
{
    public long Tid { get; set; }

    public string Reply { get; set; }

    public DateTime ReplyDate { get; set; }
}
