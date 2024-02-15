using TranslationProjectManagement.Domains.Base;
using System.Linq.Expressions;
using TranslationProjectManagement.Repositories.Base.Paging;

namespace TranslationProjectManagement.Repositories.Base.Interfaces;

public interface IGenericRepository<TDomain> : IRepository where TDomain : DomainBase
{
    Task<IPageable<TDomain>> GetPagedAsync(int offset = 0, int limit = 100, CancellationToken cancellationToken = default);

    Task<IPageable<TDomain>> GetPagedAsync(Expression<Func<TDomain, bool>> filter,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default);

    Task<IPageable<TDomain>> GetPagedAsync(IEnumerable<Expression<Func<TDomain, object>>> includes,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default);

    Task<IPageable<TDomain>> GetPagedAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default);

    Task<IPageable<TDomain>> GetPagedOrderedAsync(Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default);

    Task<IPageable<TDomain>> GetPagedOrderedAsync(Expression<Func<TDomain, bool>> filter,
        Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default);

    Task<IPageable<TDomain>> GetPagedOrderedAsync(IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default);

    Task<IPageable<TDomain>> GetPagedOrderedAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default);

    Task<IList<TDomain>> GetListAsync(CancellationToken cancellationToken = default);

    Task<IList<TDomain>> GetListAsync(Expression<Func<TDomain, bool>> filter, CancellationToken cancellationToken = default);

    Task<IList<TDomain>> GetListAsync(IEnumerable<Expression<Func<TDomain, object>>> includes, CancellationToken cancellationToken = default);

    Task<IList<TDomain>> GetListAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        CancellationToken cancellationToken = default);

    Task<IList<TDomain>> GetListOrderedAsync(Expression<Func<TDomain, object>> orderBy, CancellationToken cancellationToken = default);

    Task<IList<TDomain>> GetListOrderedAsync(Expression<Func<TDomain, bool>> filter,
        Expression<Func<TDomain, object>> orderBy,
        CancellationToken cancellationToken = default);

    Task<IList<TDomain>> GetListOrderedAsync(IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        CancellationToken cancellationToken = default);

    Task<IList<TDomain>> GetListOrderedAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        CancellationToken cancellationToken = default);

    Task<TDomain> GetOneAsync(int id, CancellationToken cancellationToken = default);

    Task<TDomain> GetOneAsync(int id, IEnumerable<Expression<Func<TDomain, object>>> includes, CancellationToken cancellationToken = default);

    Task<TDomain> GetOneAsync(Expression<Func<TDomain, bool>> filter, CancellationToken cancellationToken = default);

    Task<TDomain> GetOneAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        CancellationToken cancellationToken = default);

    Task<bool> HeadOneAsync(int id, CancellationToken cancellationToken = default);

    Task<TDomain> CreateOneAsync(TDomain entity, CancellationToken cancellationToken = default);

    Task<IList<TDomain>> CreateManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default);

    Task<TDomain> UpdateOneAsync(TDomain entity, CancellationToken cancellationToken = default);

    Task<IList<TDomain>> UpdateManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default);

    Task DeleteOneAsync(int id, CancellationToken cancellationToken = default);

    Task DeleteOneAsync(TDomain entity, CancellationToken cancellationToken = default);

    Task DeleteManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default);

    Task ClearTrackedEntitiesAsync(CancellationToken cancellationToken = default);
}
