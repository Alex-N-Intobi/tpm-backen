using IBKS.Domains;
using IBKS.Repositories.Interface;

namespace IBKS.Repositories;

public class UserRepository : GenericRepository<User, string>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
