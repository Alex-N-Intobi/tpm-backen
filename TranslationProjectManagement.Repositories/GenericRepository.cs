using Microsoft.EntityFrameworkCore;
using TranslationProjectManagement.Domains.Base;
using TranslationProjectManagement.Repositories.Base;

namespace TranslationProjectManagement.Repositories;

public class GenericRepository<TDomain> : GenericRepository<TDomain, DbContext>
    where TDomain : DomainBase
{
    public GenericRepository(DbContext dbContext) : base(dbContext) { }
}
