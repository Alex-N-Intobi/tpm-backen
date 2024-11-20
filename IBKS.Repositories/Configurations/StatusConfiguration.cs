using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IBKS.Domains;

namespace IBKS.Repositories.Configurations;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
	public void Configure(EntityTypeBuilder<Status> builder)
	{
		builder.ToTable(nameof(Status), "Support");

        builder.Property(e => e.Title).HasMaxLength(250);
    }
}
