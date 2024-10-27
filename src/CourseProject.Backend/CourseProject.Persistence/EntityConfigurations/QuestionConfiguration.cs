using CourseProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Persistence.EntityConfigurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.Property(q => q.Title)
            .IsRequired();

        builder.Property(q => q.Options)
             .HasConversion(
                 v => string.Join(',', v),
                 v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
            .Metadata.SetValueComparer(new ValueComparer<IEnumerable<string>>(
                (c1, c2) => c1.SequenceEqual(c2),  // Compare sequences
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),  // Aggregate hash codes
                c => c.ToList()  // Deep clone for tracking
            ));

        builder.Property(q => q.Type)
            .IsRequired()
            .HasConversion<string>();  
    }
}
