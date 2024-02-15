using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationProjectManagement.Domains;
using TranslationProjectManagement.Domains.Enums;

namespace TranslationProjectManagement.Repositories.Configurations;

public class ProjectItemConfiguration : IEntityTypeConfiguration<ProjectItem>
{
	public void Configure(EntityTypeBuilder<ProjectItem> builder)
	{
		builder.ToTable(nameof(ProjectItem));

		builder
			.Property(x => x.Name)
			.IsRequired();

        builder
            .Property(x => x.Description)
            .IsRequired();

        builder
            .Property(x => x.Status)
            .HasConversion(
                v => v.ToString(),
                v => (ProjectItemStatus)Enum.Parse(typeof(ProjectItemStatus), v));

        builder
            .Property(x => x.Type)
            .HasConversion(
                v => v.ToString(),
                v => (ProjectItemType)Enum.Parse(typeof(ProjectItemType), v));

        builder
            .HasOne(x => x.Project)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.AssignedUser)
            .WithMany()
            .HasForeignKey(x => x.AssignedUserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
