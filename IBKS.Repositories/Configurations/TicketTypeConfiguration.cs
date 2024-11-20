using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IBKS.Domains;

namespace IBKS.Repositories.Configurations;

public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
{
	public void Configure(EntityTypeBuilder<TicketType> builder)
	{
		builder.ToTable(nameof(TicketType), "Support");

        builder.Property(e => e.Title).HasMaxLength(250);
    }
}
