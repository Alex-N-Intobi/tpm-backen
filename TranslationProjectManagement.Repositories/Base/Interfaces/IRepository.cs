using Microsoft.EntityFrameworkCore;

namespace TranslationProjectManagement.Repositories.Base.Interfaces;

public interface IRepository<TDbContext> : IRepository
        where TDbContext : DbContext
{

}
