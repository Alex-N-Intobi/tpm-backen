using IBKS.Domains;
using IBKS.Repositories.Interface;

namespace IBKS.Repositories;

public class TicketEventLogRepository : GenericRepository<TicketEventLog, long>, ITicketEventLogRepository
{
    public TicketEventLogRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
