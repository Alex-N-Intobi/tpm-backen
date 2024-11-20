namespace IBKS.Contracts;

public class TicketReply
{
    public int ReplyId { get; set; }

    public long Tid { get; set; }

    public string Reply { get; set; }

    public DateTime ReplyDate { get; set; }
}
