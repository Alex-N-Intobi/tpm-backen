using IBKS.Domains.Base;

namespace IBKS.Domains;

public class TicketReply: DomainBase<int>
{
    public long Tid { get; set; }

    public string Reply { get; set; }

    public DateTime ReplyDate { get; set; }
}
