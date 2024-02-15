using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationProjectManagement.Domains;

namespace TranslationProjectManagement.Repositories.Configurations;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
	public void Configure(EntityTypeBuilder<RoleClaim> builder)
	{
		builder.ToTable(nameof(RoleClaim));

        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.Claims)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
