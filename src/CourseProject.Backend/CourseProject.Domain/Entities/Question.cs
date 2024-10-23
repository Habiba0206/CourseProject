using CourseProject.Domain.Common.Entities;
using CourseProject.Domain.Enums;

namespace CourseProject.Domain.Entities;

public class Question : AuditableEntity
{
    public Guid TemplateId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public QuestionType Type { get; set; }
    public IEnumerable<string> Options { get; set; }
    public bool DisplayInResults { get; set; }
    public Template Template { get; set; }
}
