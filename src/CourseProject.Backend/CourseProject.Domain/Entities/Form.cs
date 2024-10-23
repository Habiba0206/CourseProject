using CourseProject.Domain.Common.Entities;

namespace CourseProject.Domain.Entities;

public class Form : AuditableEntity
{
    public Guid UserId { get; set; }
    public Guid TemplateId { get; set; }
    public DateTime DateSubmitted { get; set; }
    public User User { get; set; }
    public Template Template { get; set; }
    public IEnumerable<Answer> Answers { get; set; }
}
