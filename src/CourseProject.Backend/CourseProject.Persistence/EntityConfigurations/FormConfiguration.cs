using CourseProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Persistence.EntityConfigurations;

public class FormConfiguration : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.HasMany(f => f.Answers)
            .WithOne(a => a.Form)
            .HasForeignKey(a => a.FormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Template)
            .WithMany(t => t.Forms)
            .HasForeignKey(f => f.TemplateId);
    }
}
