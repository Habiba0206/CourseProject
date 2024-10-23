using CourseProject.Application.Answers.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Answers.Queries;

public class AnswerGetByIdQuery : IQuery<AnswerDto?>
{
    public Guid AnswerId { get; set; }
}
