using Microsoft.EntityFrameworkCore;

namespace IBKS.Repositories.Base.Interfaces;

public interface IRepository<TDbContext> : IRepository
        where TDbContext : DbContext
{

}
