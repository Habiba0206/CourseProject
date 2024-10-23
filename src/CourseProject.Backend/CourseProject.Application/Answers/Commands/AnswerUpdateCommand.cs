using CourseProject.Application.Answers.Models;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Answers.Commands;

public class AnswerUpdateCommand : ICommand<AnswerDto>
{
    public AnswerDto AnswerDto { get; set; }
}
