using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IBKS.Domains;

namespace IBKS.Repositories.Configurations;

public class LogTypeConfiguration : IEntityTypeConfiguration<LogType>
{
	public void Configure(EntityTypeBuilder<LogType> builder)
	{
		builder.ToTable(nameof(LogType), "Support");

        builder.Property(e => e.Title).HasMaxLength(250);
    }
}
