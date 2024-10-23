using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Questions.Commands;

public class QuestionDeleteByIdCommand : ICommand<bool>
{
    public Guid QuestionId { get; set; }
}
