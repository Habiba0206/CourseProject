using CourseProject.Application.Answers.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Answers.Queries;

public class AnswerGetQuery : IQuery<ICollection<AnswerDto>>
{
    public AnswerFilter AnswerFilter { get; set; }
}
