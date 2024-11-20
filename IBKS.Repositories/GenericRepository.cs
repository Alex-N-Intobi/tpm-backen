using Microsoft.EntityFrameworkCore;
using IBKS.Domains.Base;
using IBKS.Repositories.Base;

namespace IBKS.Repositories;

public class GenericRepository<TDomain, TKey> : GenericRepository<TDomain, TKey, DbContext>
    where TDomain : DomainBase<TKey>
{
    public GenericRepository(DbContext dbContext) : base(dbContext) { }
}
