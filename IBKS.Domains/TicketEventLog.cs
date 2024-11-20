using IBKS.Domains.Base;

namespace IBKS.Domains;

public class TicketEventLog : DomainBase<long>
{
    public int LogTypeId { get; set; }

    public long TicketId { get; set; }

    public int UserId { get; set; }

    public DateTime EventDt { get; set; }

    public string Message { get; set; }

    public LogType LogType { get; set; }

    public Ticket Ticket { get; set; }
}
