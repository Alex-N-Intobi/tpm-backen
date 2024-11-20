using Microsoft.EntityFrameworkCore.Storage;

namespace IBKS.Repositories.Base.Interfaces;

public interface IUnitOfWork
{
    bool HasActiveTransaction();

    IDbContextTransaction GetCurrentTransaction();

    Task CommitAsync(CancellationToken cancellationToken = default);

    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    Task CommitTransactionAsync(IDbContextTransaction transaction, CancellationToken cancellationToken = default);

    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
