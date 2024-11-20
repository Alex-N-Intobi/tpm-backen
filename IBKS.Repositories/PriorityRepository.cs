using IBKS.Domains;
using IBKS.Repositories.Interface;

namespace IBKS.Repositories;

public class PriorityRepository : GenericRepository<Priority, int>, IPriorityRepository
{
    public PriorityRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
