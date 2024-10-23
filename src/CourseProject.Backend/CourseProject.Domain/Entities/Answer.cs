using CourseProject.Domain.Common.Entities;

namespace CourseProject.Domain.Entities;

public class Answer : AuditableEntity
{
    public Guid FormId { get; set; }
    public Guid QuestionId { get; set; }
    public string Value { get; set; }
    public Form Form { get; set; }
    public Question Question { get; set; } 
}
