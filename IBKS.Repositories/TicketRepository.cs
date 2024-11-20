using IBKS.Domains;
using IBKS.Repositories.Interface;

namespace IBKS.Repositories;

public class TicketRepository : GenericRepository<Ticket, long>, ITicketRepository
{
    public TicketRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
