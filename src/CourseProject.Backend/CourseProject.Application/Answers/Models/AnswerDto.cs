namespace CourseProject.Application.Answers.Models;

public class AnswerDto
{
    public Guid? Id { get; set; }
    public Guid FormId { get; set; }
    public Guid QuestionId { get; set; }
    public string Value { get; set; }
}
