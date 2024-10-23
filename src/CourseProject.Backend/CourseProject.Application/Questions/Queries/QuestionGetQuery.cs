using CourseProject.Application.Questions.Models;
using CourseProject.Application.Templates.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Questions.Queries;

public class QuestionGetQuery : IQuery<ICollection<QuestionDto>>
{
    public QuestionFilter QuestionFilter { get; set; }
}
