using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IBKS.Domains;

namespace IBKS.Repositories.Configurations;

public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
{
	public void Configure(EntityTypeBuilder<Priority> builder)
	{
		builder.ToTable(nameof(Priority), "Support");

        builder.Property(e => e.Title).HasMaxLength(250);
    }
}
