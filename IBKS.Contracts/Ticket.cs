using IBKS.Contracts.Base;

namespace IBKS.Contracts;

public class Ticket : ContractBase<long>
{
    public string Title { get; set; }

    public int ApplicationId { get; set; }

    public string ApplicationName { get; set; }

    public string Description { get; set; }

    public string Url { get; set; }

    public string StackTrace { get; set; }

    public string Device { get; set; }

    public string Browser { get; set; }

    public string Resolution { get; set; }

    public int PriorityId { get; set; }

    public int StatusId { get; set; }

    public int? UserId { get; set; }

    public string UserOid { get; set; }

    public int InstalledEnvironmentId { get; set; }

    public int TicketTypeId { get; set; }

    public DateTime Date { get; set; }

    public bool? Deleted { get; set; }

    public DateTime LastModified { get; set; }

    public string CreatedByOid { get; set; }

    public InstalledEnvironment InstalledEnvironment { get; set; }

    public Priority Priority { get; set; }

    public Status Status { get; set; }

    public ICollection<TicketEventLog> TicketEventLogs { get; set; }

    public TicketType TicketType { get; set; }

    public User UserO { get; set; }
}
