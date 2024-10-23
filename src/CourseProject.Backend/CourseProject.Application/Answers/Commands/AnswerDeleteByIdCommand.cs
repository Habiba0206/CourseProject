using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Answers.Commands;

public class AnswerDeleteByIdCommand : ICommand<bool>
{
    public Guid AnswerId { get; set; }
}
