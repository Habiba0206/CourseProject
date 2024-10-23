using CourseProject.Application.Questions.Models;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Questions.Commands;

public record QuestionCreateCommand : ICommand<QuestionDto>
{
    public QuestionDto QuestionDto { get; set; }
}
