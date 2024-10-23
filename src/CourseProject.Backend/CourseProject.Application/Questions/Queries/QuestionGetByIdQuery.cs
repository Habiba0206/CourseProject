using CourseProject.Application.Forms.Models;
using CourseProject.Application.Questions.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Questions.Queries;

public class QuestionGetByIdQuery : IQuery<QuestionDto?>
{
    public Guid QuestionId { get; set; }
}
