using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IBKS.Domains;

namespace IBKS.Repositories.Configurations;

public class TicketEventLogConfiguration : IEntityTypeConfiguration<TicketEventLog>
{
	public void Configure(EntityTypeBuilder<TicketEventLog> builder)
	{
		builder.ToTable(nameof(TicketEventLog), "Support");

        builder.HasIndex(e => e.LogTypeId, "IX_TicketEventLog_LogTypeId");
        builder.HasIndex(e => e.TicketId, "IX_TicketEventLog_TicketId");

        builder.HasOne(d => d.LogType).WithMany(p => p.TicketEventLogs).HasForeignKey(d => d.LogTypeId);
        builder.HasOne(d => d.Ticket).WithMany(p => p.TicketEventLogs).HasForeignKey(d => d.TicketId);
    }
}
