using System.Linq.Expressions;
using IBKS.Domains.Base;
using IBKS.Repositories.Base.Exceptions;
using IBKS.Repositories.Base.Interfaces;
using IBKS.Repositories.Base.Options;
using IBKS.Repositories.Base.Paging;
using IBKS.Services.Base.Interfaces;

namespace IBKS.Services.Base;

public class ServiceBase<TDomain, TKey> : IServiceBase<TDomain, TKey> where TDomain : DomainBase<TKey>
{
    private readonly IGenericRepository<TDomain, TKey> _genericRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ServiceBase(IGenericRepository<TDomain, TKey> genericRepository,
        IUnitOfWork unitOfWork)
    {
        _genericRepository = genericRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IPageable<TDomain>> GetManyAsync(int offset, int limit, CancellationToken cancellationToken = default)
    {
        return await _genericRepository.GetPagedAsync(offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetManyAsync(RequestManyOptions searchOptions, CancellationToken cancellationToken = default)
    {
        searchOptions = searchOptions ?? throw new ArgumentNullException(nameof(searchOptions));

        IEnumerable<Expression<Func<TDomain, object>>> includes = GetIncludeExpressions(searchOptions);

        return await _genericRepository.GetPagedAsync(includes, searchOptions.Offset, searchOptions.Limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedAsync(Expression<Func<TDomain, bool>> filter,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));

        return await _genericRepository.GetPagedAsync(filter, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedAsync(IEnumerable<Expression<Func<TDomain, object>>> includes,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await _genericRepository.GetPagedAsync(includes, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await _genericRepository.GetPagedAsync(filter, includes, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedOrderedAsync(Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await _genericRepository.GetPagedOrderedAsync(orderBy, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedOrderedAsync(Expression<Func<TDomain, bool>> filter,
        Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await _genericRepository.GetPagedOrderedAsync(filter, orderBy, offset, limit, cancellationToken);
    }
    public async Task<IPageable<TDomain>> GetPagedOrderedAsync(IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        includes = includes ?? throw new ArgumentNullException(nameof(includes));
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await _genericRepository.GetPagedOrderedAsync(includes, orderBy, offset, limit, cancellationToken);
    }

    public async Task<IPageable<TDomain>> GetPagedOrderedAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        int offset = 0,
        int limit = 100,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await _genericRepository.GetPagedOrderedAsync(filter, includes, orderBy, offset, limit, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _genericRepository.GetListAsync(cancellationToken);
    }

    public async Task<IList<TDomain>> GetListAsync(Expression<Func<TDomain, bool>> filter, CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));

        return await _genericRepository.GetListAsync(filter, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListAsync(IEnumerable<Expression<Func<TDomain, object>>> includes, CancellationToken cancellationToken = default)
    {
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await _genericRepository.GetListAsync(includes, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await _genericRepository.GetListAsync(filter, includes, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListOrderedAsync(Expression<Func<TDomain, object>> orderBy, CancellationToken cancellationToken = default)
    {
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await _genericRepository.GetListOrderedAsync(orderBy, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListOrderedAsync(Expression<Func<TDomain, bool>> filter,
        Expression<Func<TDomain, object>> orderBy,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await _genericRepository.GetListOrderedAsync(filter, orderBy, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListOrderedAsync(IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        CancellationToken cancellationToken = default)
    {
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await _genericRepository.GetListOrderedAsync(includes, orderBy, cancellationToken);
    }

    public async Task<IList<TDomain>> GetListOrderedAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        Expression<Func<TDomain, object>> orderBy,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        includes = includes ?? throw new ArgumentNullException(nameof(includes));
        orderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));

        return await _genericRepository.GetListOrderedAsync(filter, includes, orderBy, cancellationToken);
    }

    public async Task<TDomain> GetOneAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await _genericRepository.GetOneAsync(id, cancellationToken);
    }

    public async Task<TDomain> GetOneAsync(TKey id, RequestOneOptions searchOptions, CancellationToken cancellationToken = default)
    {
        searchOptions = searchOptions ?? throw new ArgumentNullException(nameof(searchOptions));

        return await _genericRepository.GetOneAsync(id, GetIncludeExpressions(searchOptions), cancellationToken);
    }

    public async Task<TDomain> GetOneAsync(TKey id, IEnumerable<Expression<Func<TDomain, object>>> includes, CancellationToken cancellationToken = default)
    {
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await _genericRepository.GetOneAsync(id, includes, cancellationToken);
    }

    public async Task<TDomain> GetOneAsync(Expression<Func<TDomain, bool>> filter, CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));

        return await _genericRepository.GetOneAsync(filter, cancellationToken);
    }

    public async Task<TDomain> GetOneAsync(Expression<Func<TDomain, bool>> filter,
        IEnumerable<Expression<Func<TDomain, object>>> includes,
        CancellationToken cancellationToken = default)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));
        includes = includes ?? throw new ArgumentNullException(nameof(includes));

        return await _genericRepository.GetOneAsync(filter, includes, cancellationToken);
    }

    public async Task<bool> HeadOneAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await _genericRepository.HeadOneAsync(id, cancellationToken);
    }

    public async Task<TDomain> CreateOneAsync(TDomain entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(nameof(entity));

        TDomain created = await _genericRepository.CreateOneAsync(entity, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return created;
    }

    public async Task<IList<TDomain>> CreateManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(nameof(entities));

        entities = entities.Where(x => x != null).ToList();

        if (!entities.Any())
        {
            throw new InvalidOperationException("No entities to create.");
        }

        IList<TDomain> result = await _genericRepository.CreateManyAsync(entities, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return result;
    }

    public async Task<TDomain> UpdateOneAsync(TKey id, TDomain entity, CancellationToken cancellationToken = default)
    {

        ArgumentNullException.ThrowIfNull(nameof(entity));

        TDomain current = await GetOneAsync(id, cancellationToken);
        if (current == null)
        {
            throw new NotFoundException($"Resource not found with Id: '{id}'.");
        }

        if (!EqualityComparer<TKey>.Default.Equals(entity.Id, id))
        {
            throw new InvalidOperationException($"Resource Id doesn't match with the Entity Id. ResourceId: '{id}', EntityId:' {entity.Id}'.");
        }

        TDomain updatedEntity = await _genericRepository.UpdateOneAsync(entity, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return updatedEntity;
    }

    public async Task<IList<TDomain>> UpdateManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(nameof(entities));

        if (!entities.Any())
        {
            throw new ArgumentException("The list of entities cannot be empty.", nameof(entities));
        }

        entities = entities.DistinctBy(x => x.Id).ToList();

        TKey[] entityIds = entities.Select(x => x.Id).ToArray();
        IList<TDomain> existingEntities = await GetListAsync(x => entityIds.Contains(x.Id), cancellationToken);

        List<TDomain> nonExistingEntities = entities
            .Where(x => existingEntities.SingleOrDefault(y => x.Id.Equals(y.Id)) == null)
            .ToList();

        if (nonExistingEntities.Count > 0)
        {
            throw new InvalidOperationException($"The following entities are not found in the database: {string.Join(", ", nonExistingEntities.Select(x => x.Id))}.");
        }


        IList<TDomain> result = await _genericRepository.UpdateManyAsync(entities, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return result;
    }

    public async Task DeleteOneAsync(TKey id, CancellationToken cancellationToken = default)
    {
        if (!await HeadOneAsync(id, cancellationToken))
        {
            throw new NotFoundException($"Resource not found with Id: '{id}' to Delete.");
        }

        await _genericRepository.DeleteOneAsync(id, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task DeleteOneAsync(TDomain entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await DeleteOneAsync(entity.Id, cancellationToken);
    }

    public async Task DeleteManyAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default)
    {
        if (!ids.Any())
        {
            throw new ArgumentException("Ids can't be empty.", nameof(ids));
        }

        IList<TDomain> entitiesToDelete = await GetListAsync(x => ids.Contains(x.Id), cancellationToken);

        await DeleteManyAsync(entitiesToDelete, cancellationToken);
    }

    public async Task DeleteManyAsync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entities);

        if (!entities.Any())
        {
            return;
        }

        await _genericRepository.DeleteManyAsync(entities, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    protected IList<Expression<Func<TEntity, object>>> GetIncludeExpressions<TEntity>(RequestOneOptions searchOptions)
        where TEntity : DomainBase<TKey>
    {
        return searchOptions
            ?.IncludeProperties
            .Select(GetIncludeExpression<TEntity>)
            .ToList();
    }

    protected IList<Expression<Func<TDomain, object>>> GetIncludeExpressions(RequestOneOptions searchOptions)
    {
        return GetIncludeExpressions<TDomain>(searchOptions);
    }

    private static Expression<Func<TEntity, object>> GetIncludeExpression<TEntity>(string propertyName)
        where TEntity : DomainBase<TKey>
    {
        ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "entity");
        Expression right;

        if (propertyName.Contains('.'))
        {
            right = Expression.Constant(propertyName);
        }
        else
        {
            right = Expression.Property(parameter, propertyName);
        }

        return Expression.Lambda<Func<TEntity, object>>(right, parameter);
    }
}