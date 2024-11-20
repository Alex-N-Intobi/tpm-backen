using IBKS.Domains;
using IBKS.Repositories.Interface;

namespace IBKS.Repositories;

public class TicketTypeRepository : GenericRepository<TicketType, int>, ITicketTypeRepository
{
    public TicketTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
