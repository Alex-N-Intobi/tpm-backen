using IBKS.Domains;
using IBKS.Repositories.Interface;

namespace IBKS.Repositories;

public class TicketReplyRepository : GenericRepository<TicketReply, int>, ITicketReplyRepository
{
    public TicketReplyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
