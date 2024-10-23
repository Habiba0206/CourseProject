using CourseProject.Domain.Enums;

namespace CourseProject.Application.Questions.Models;

public class QuestionDto
{
    public Guid? Id { get; set; }
    public Guid TemplateId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public QuestionType Type { get; set; }
    public IEnumerable<string> Options { get; set; }
    public bool DisplayInResults { get; set; }
}
