using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IBKS.Domains;

namespace IBKS.Repositories.Configurations;

public class TicketReplyConfiguration : IEntityTypeConfiguration<TicketReply>
{
	public void Configure(EntityTypeBuilder<TicketReply> builder)
	{
		builder.ToTable(nameof(TicketReply), "Support");

        builder.Property(e => e.Tid).HasColumnName("TId");
    }
}
