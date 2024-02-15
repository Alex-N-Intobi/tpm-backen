using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TranslationProjectManagement.Domains;
using TranslationProjectManagement.Repositories.Base.Constants;
using TranslationProjectManagement.Repositories.Base.Interfaces;
using TranslationProjectManagement.Repositories.Extensions;

namespace TranslationProjectManagement.Repositories;

public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    private readonly IIdentityManager _identityManager;

    public ApplicationDbContext(DbContextOptions options,
        IIdentityManager identityManager) : base(options)
    {
        _identityManager = identityManager;
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
            .ToList();

        foreach (EntityEntry entity in entries)
        {
            if (entity.State == EntityState.Modified)
            {
                entity.TrySetPropertyCurrentValue(DbContextConstants.ModifiedDate, DateTimeOffset.UtcNow);
                entity.TrySetPropertyCurrentValue(DbContextConstants.ModifiedById, _identityManager.GetCurrentApplicationUserId());

                entity.TrySetPropertyIsModified(DbContextConstants.CreatedDate, false);
                entity.TrySetPropertyIsModified(DbContextConstants.CreatedById, false);
            }
            else if (entity.State == EntityState.Added)
            {
                entity.TrySetPropertyCurrentValue(DbContextConstants.CreatedDate, DateTimeOffset.UtcNow);
                entity.TrySetPropertyCurrentValue(DbContextConstants.CreatedById, _identityManager.GetCurrentApplicationUserId());
            }
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return SaveChangesAsync(true, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
