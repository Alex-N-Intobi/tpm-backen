using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationProjectManagement.Domains;

namespace TranslationProjectManagement.Repositories.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
	public void Configure(EntityTypeBuilder<Project> builder)
	{
		builder.ToTable(nameof(Project));

		builder
			.Property(x => x.Name)
			.IsRequired();
	}
}
