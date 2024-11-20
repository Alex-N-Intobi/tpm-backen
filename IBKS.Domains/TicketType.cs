﻿using IBKS.Domains.Base;

namespace IBKS.Domains;

public class TicketType : DomainBase<int>
{
    public string Title { get; set; }

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
