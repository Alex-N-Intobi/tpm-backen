using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IBKS.Domains;

namespace IBKS.Repositories.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
	public void Configure(EntityTypeBuilder<Ticket> builder)
	{
		builder.ToTable(nameof(Ticket), "Support");

        builder.HasIndex(e => e.InstalledEnvironmentId, "IX_Ticket_InstalledEnvironmentId");
        builder.HasIndex(e => e.PriorityId, "IX_Ticket_PriorityId");
        builder.HasIndex(e => e.StatusId, "IX_Ticket_StatusId");
        builder.HasIndex(e => e.TicketTypeId, "IX_Ticket_TicketTypeId");
        builder.HasIndex(e => e.UserOid, "IX_Ticket_UserOID");

        builder.Property(e => e.ApplicationName).HasMaxLength(250);
        builder.Property(e => e.Browser).HasMaxLength(250);
        builder.Property(e => e.CreatedByOid).HasColumnName("CreatedByOID");
        builder.Property(e => e.Device).HasMaxLength(250);
        builder.Property(e => e.Title).HasMaxLength(250);
        builder.Property(e => e.Url).HasMaxLength(1000);
        builder.Property(e => e.UserOid)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("UserOID");

        builder.HasOne(d => d.InstalledEnvironment).WithMany(p => p.Tickets).HasForeignKey(d => d.InstalledEnvironmentId);
        builder.HasOne(d => d.Priority).WithMany(p => p.Tickets).HasForeignKey(d => d.PriorityId);
        builder.HasOne(d => d.Status).WithMany(p => p.Tickets).HasForeignKey(d => d.StatusId);
        builder.HasOne(d => d.TicketType).WithMany(p => p.Tickets).HasForeignKey(d => d.TicketTypeId);
        builder.HasOne(d => d.UserO).WithMany(p => p.Tickets).HasForeignKey(d => d.UserOid);
    }
}
