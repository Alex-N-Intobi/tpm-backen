using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IBKS.Domains;

namespace IBKS.Repositories.Configurations;

public class InstalledEnvironmentConfiguration : IEntityTypeConfiguration<InstalledEnvironment>
{
	public void Configure(EntityTypeBuilder<InstalledEnvironment> builder)
    {
        builder
            .ToTable(nameof(InstalledEnvironment), "Support")
            .HasKey(x => x.Id);

        builder.Property(e => e.Title).HasMaxLength(250);
	}
}
