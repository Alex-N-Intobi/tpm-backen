using System.Linq.Expressions;
using TranslationProjectManagement.Repositories.Base.Options;
using TranslationProjectManagement.Repositories.Base.Paging;

namespace TranslationProjectManagement.Services.Base.Interfaces;

public interface IServiceBase<TDomain> : IServiceBase where TDomain : class
{
    Task<IPageable<TDomain>> GetManyAsync(int offset, int limit, CancellationToken cancellationToken = default);

    Task<IPageable<TDomain>> GetManyAsync(RequestManyOptions searchOptions, CancellationToken cancellationToken = default);

    Task<IPageable<TDomain>> GetPagedAsync(IEnumerable<Expression<Func<TDomain, object>>> includes,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default);

    Task<IPageable<TDomain>> GetPagedAsync(Expression<Func<TDomain, bool>> filter,
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

    Task<TDomain> GetOneAsync(int id, RequestOneOptions searchOptions, CancellationToken cancellationToken = default);

    Task<TDomain> GetOneAsync(int id, IEnumerable<Expression<Func<TDomain, object>>> includes, CancellationToken cancellationToken = default);

    Task<TDomain> GetOneAsync(Expression<Func<TDomain, bool>> filter, CancellationToken cancellationToken = default);

    Task<TDomain> GetOneAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        CancellationToken cancellationToken = default);

    Task<bool> HeadOneAsync(int id, CancellationToken cancellationToken = default);

    Task<TDomain> CreateOneAsync(TDomain entity, CancellationToken cancellationToken = default);

    Task<IList<TDomain>> CreateManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default);

    Task<TDomain> UpdateOneAsync(int id, TDomain entity, CancellationToken cancellationToken = default);

    Task<IList<TDomain>> UpdateManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default);

    Task DeleteOneAsync(int id, CancellationToken cancellationToken = default);

    Task DeleteOneAsync(TDomain entity, CancellationToken cancellationToken = default);

    Task DeleteManyAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default);

    Task DeleteManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default);
}
