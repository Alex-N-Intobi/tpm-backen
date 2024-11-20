using IBKS.Domains;
using IBKS.Repositories.Interface;

namespace IBKS.Repositories;

public class StatusRepository : GenericRepository<Status, int>, IStatusRepository
{
    public StatusRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
