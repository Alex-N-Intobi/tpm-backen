namespace IBKS.Contracts;

public class User
{
    public string Oid { get; set; }

    public string DisplayName { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public DateTime? LastScannedUtc { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}
