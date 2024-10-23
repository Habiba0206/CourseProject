using CourseProject.Domain.Common.Entities;

namespace CourseProject.Domain.Entities;

public class Template : AuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsPublic { get; set; }
    public IEnumerable<Form> Forms { get; set; }
    public IEnumerable<Question> Questions { get; set; }
}
