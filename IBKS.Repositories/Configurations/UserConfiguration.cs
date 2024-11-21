using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IBKS.Domains;

namespace IBKS.Repositories.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable(nameof(User), "Support");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("OID");

        builder.Property(e => e.DisplayName)
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(e => e.Email)
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(e => e.FullName)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
