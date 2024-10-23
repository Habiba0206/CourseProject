using CourseProject.Application.Questions.Models;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Questions.Commands;

public class QuestionUpdateCommand : ICommand<QuestionDto>
{
    public QuestionDto QuestionDto { get; set; }
}
