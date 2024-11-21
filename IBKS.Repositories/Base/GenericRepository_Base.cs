using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using IBKS.Domains.Base;
using IBKS.Repositories.Base.Exceptions;
using IBKS.Repositories.Base.Interfaces;
using IBKS.Repositories.Base.Paging;

namespace IBKS.Repositories.Base;

public class GenericRepository<TDomain, TKey, TDbContext> : IGenericRepository<TDomain, TKey>
    where TDomain : DomainBase<TKey>
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    private readonly DbSet<TDomain> DbSet;

    public GenericRepository(TDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        DbSet = dbContext.Set<TDomain>();
    }

    public async Task<IPageable<TDomain>> GetPagedAsync(int offset = 0, int limit = 100, CancellationToken cancellationToken = default)
    {
        return await GetPagedInternalAsync(filter: null, includes: null, orderBy: null, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedAsync(Expression<Func<TDomain, bool>> filter,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));

        return await GetPagedInternalAsync(filter: filter, includes: null, orderBy: null, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedAsync(IEnumerable<Expression<Func<TDomain, object>>> includes,
       int offset = 0,
       int limit = 100,
       CancellationToken cancellationToken = default)
    {
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await GetPagedInternalAsync(filter: null, includes: includes, orderBy: null, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await GetPagedInternalAsync(filter: filter, includes: includes, orderBy: null, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedOrderedAsync(Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await GetPagedInternalAsync(filter: null, includes: null, orderBy: orderBy, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedOrderedAsync(IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        includes = includes ?? throw new ArgumentNullException(nameof(includes));
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await GetPagedInternalAsync(filter: null, includes: includes, orderBy: orderBy, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedOrderedAsync(Expression<Func<TDomain, bool>> filter,
        Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await GetPagedInternalAsync(filter: filter, includes: null, orderBy: orderBy, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedOrderedAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        includes = includes ?? throw new ArgumentNullException(nameof(includes));
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await GetPagedInternalAsync(filter: filter, includes: includes, orderBy: orderBy, offset, limit, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await GetListInternalAsync(filter: null, includes: null, orderBy: null, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListAsync(Expression<Func<TDomain, bool>> filter, CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));

        return await GetListInternalAsync(filter: filter, includes: null, orderBy: null, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListAsync(IEnumerable<Expression<Func<TDomain, object>>> includes, CancellationToken cancellationToken = default)
    {
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await GetListInternalAsync(filter: null, includes: includes, orderBy: null, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await GetListInternalAsync(filter: filter, includes: includes, orderBy: null, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListOrderedAsync(Expression<Func<TDomain, object>> orderBy, CancellationToken cancellationToken = default)
    {
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await GetListInternalAsync(filter: null, includes: null, orderBy: orderBy, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListOrderedAsync(Expression<Func<TDomain, bool>> filter,
        Expression<Func<TDomain, object>> orderBy,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await GetListInternalAsync(filter: filter, includes: null, orderBy: orderBy, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListOrderedAsync(IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        CancellationToken cancellationToken = default)
    {
        includes = includes ?? throw new ArgumentNullException(nameof(includes));
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await GetListInternalAsync(filter: null, includes: includes, orderBy: orderBy, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListOrderedAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        includes = includes ?? throw new ArgumentNullException(nameof(includes));
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await GetListInternalAsync(filter: filter, includes: includes, orderBy: orderBy, cancellationToken);
    }

    public async Task<TDomain> GetOneAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await GetOneInternalAsync(x => x.Id.Equals(id), null, cancellationToken: cancellationToken);
    }

    public async Task<TDomain> GetOneAsync(TKey id, IEnumerable<Expression<Func<TDomain, object>>> includes, CancellationToken cancellationToken = default)
    {
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await GetOneInternalAsync(x => x.Id.Equals(id), includes, cancellationToken);
    }

    public async Task<TDomain> GetOneAsync(Expression<Func<TDomain, bool>> filter, CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));

        return await GetOneInternalAsync(filter, null, cancellationToken);
    }

    public async Task<TDomain> GetOneAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await GetOneInternalAsync(filter, includes, cancellationToken);
    }

    public async Task<bool> HeadOneAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(i => i.Id.Equals(id), cancellationToken);
    }

    public async Task<TDomain> CreateOneAsync(TDomain entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task<IList<TDomain>> CreateManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default)
    {
        await DbSet.AddRangeAsync(entities, cancellationToken);

        return entities.ToList();
    }

    public async Task<TDomain> UpdateOneAsync(TDomain entity, CancellationToken cancellationToken = default)
    {
        DbSet.Update(entity);

        return await Task.FromResult(entity);
    }

    public async Task<IList<TDomain>> UpdateManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default)
    {
        DbSet.UpdateRange(entities);

        return await Task.FromResult(entities.ToList());
    }

    public async Task DeleteOneAsync(TKey id, CancellationToken cancellationToken = default)
    {
        TDomain entity = await DbSet.SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken: cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(entity));
        }

        await DeleteOneAsync(entity, cancellationToken);
    }

    public async Task DeleteOneAsync(TDomain entity, CancellationToken cancellationToken = default)
    {
        entity = entity ?? throw new ArgumentNullException(nameof(entity));

        DbSet.Remove(entity);

        await Task.CompletedTask;
    }


    public async Task DeleteManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default)
    {
        DbSet.RemoveRange(entities);

        await Task.CompletedTask;
    }

    public Task ClearTrackedEntitiesAsync(CancellationToken cancellationToken = default)
    {
        _dbContext.ChangeTracker.Clear();

        return Task.CompletedTask;
    }

    protected async Task<T> UpdateOneAsync<T>(T entity, params Expression<Func<T, object>>[] navigations) where T : DomainBase<TKey>
    {
        entity = entity ?? throw new ArgumentNullException(nameof(entity));

        T dbEntity = await _dbContext.FindAsync<T>(entity.Id);

        EntityEntry<T> dbEntry = _dbContext.Entry(dbEntity);

        dbEntry.CurrentValues.SetValues(entity);

        foreach (Expression<Func<T, object>> property in navigations)
        {
            string propertyName = property.GetPropertyAccess().Name;
            CollectionEntry dbItemsEntry = dbEntry.Collection(propertyName);

            await dbItemsEntry.LoadAsync();
            var dbItemsMap = ((IEnumerable<DomainBase<TKey>>) dbItemsEntry.CurrentValue).ToDictionary(e => e.Id);

            IClrCollectionAccessor accessor = dbItemsEntry.Metadata.GetCollectionAccessor();
            var items = (IEnumerable<DomainBase<TKey>>) accessor.GetOrCreate(entity, true);

            foreach (DomainBase<TKey> item in items)
            {
                if (!dbItemsMap.TryGetValue(item.Id, out DomainBase<TKey> oldItem))
                {
                    accessor.Add(dbEntity, item, true);
                }
                else
                {
                    _dbContext.Entry(oldItem).CurrentValues.SetValues(item);
                    dbItemsMap.Remove(item.Id);
                }
            }

            foreach (DomainBase<TKey> oldItem in dbItemsMap.Values)
            {
                accessor.Remove(dbEntity, oldItem);
            }
        }

        return dbEntry.Entity;
    }

    private async Task<IPageable<TDomain>> GetPagedInternalAsync(Expression<Func<TDomain, bool>> filter = null,
        IEnumerable<Expression<Func<TDomain, object>>> includes = null,
        Expression<Func<TDomain, object>> orderBy = null,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        if (limit == 0)
        {
            limit = int.MaxValue;
        }

        IQueryable<TDomain> query = GenerateListQuery(filter, includes, orderBy);
        List<TDomain> pagedData = await query
            .Skip(offset)
            .Take(limit)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new Pageable<TDomain>(pagedData, query.Count());
    }

    private async Task<TDomain> GetOneInternalAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TDomain> query = DbSet.Where(filter);

        query = GenerateIncludeQuery(query, includes);

        return await query
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);
    }

    private async Task<List<TDomain>> GetListInternalAsync(Expression<Func<TDomain, bool>> filter = null,
        IEnumerable<Expression<Func<TDomain, object>>> includes = null,
        Expression<Func<TDomain, object>> orderBy = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TDomain> query = GenerateListQuery(filter, includes, orderBy);

        return await query
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    private IQueryable<TDomain> GenerateListQuery(Expression<Func<TDomain, bool>> filter = null,
        IEnumerable<Expression<Func<TDomain, object>>> includes = null,
        Expression<Func<TDomain, object>> orderBy = null)
    {
        IQueryable<TDomain> query = DbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        query = GenerateIncludeQuery(query, includes);

        orderBy ??= (x => x.Id);

        query = query.OrderBy(orderBy);

        return query;
    }

    private IQueryable<TDomain> GenerateIncludeQuery(IQueryable<TDomain> query, IEnumerable<Expression<Func<TDomain, object>>> includes = null)
    {
        if (includes?.Any() != true)
        {
            return query;
        }

        foreach (Expression<Func<TDomain, object>> include in includes)
        {
            if (include.Body.NodeType == ExpressionType.Constant)
            {
                string memberName = include.Body.ToString().Replace("\"", "");
                query = query.Include(memberName);
            }
            else
            {
                query = query.Include(include);
            }
        }

        return query;
    }
}
