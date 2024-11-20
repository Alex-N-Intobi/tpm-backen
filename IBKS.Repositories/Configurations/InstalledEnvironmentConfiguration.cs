using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IBKS.Domains;
using IBKS.Domains;

namespace IBKS.Repositories.Configurations;

public class InstalledEnvironmentConfiguration : IEntityTypeConfiguration<InstalledEnvironment>
{
	public void Configure(EntityTypeBuilder<InstalledEnvironment> builder)
    {
        builder.ToTable(nameof(InstalledEnvironment), "Support");

        builder.Property(e => e.Title).HasMaxLength(250);
	}
}
