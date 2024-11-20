using IBKS.Domains.Base;

namespace IBKS.Domains;

public class LogType : DomainBase<int>
{
    public string Title { get; set; }

    public ICollection<TicketEventLog> TicketEventLogs { get; set; }
}
