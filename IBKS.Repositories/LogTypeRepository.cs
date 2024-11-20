using IBKS.Domains;
using IBKS.Repositories.Interface;

namespace IBKS.Repositories;

public class LogTypeRepository : GenericRepository<LogType, int>, ILogTypeRepository
{
    public LogTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
