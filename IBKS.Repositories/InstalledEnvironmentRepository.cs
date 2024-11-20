using IBKS.Domains;
using IBKS.Repositories.Interface;

namespace IBKS.Repositories;

public class InstalledEnvironmentRepository : GenericRepository<InstalledEnvironment, int>, IInstalledEnvironmentRepository
{
    public InstalledEnvironmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
