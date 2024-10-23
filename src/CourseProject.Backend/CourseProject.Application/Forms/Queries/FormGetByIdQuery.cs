using CourseProject.Application.Answers.Models;
using CourseProject.Application.Forms.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Forms.Queries;

public class FormGetByIdQuery : IQuery<FormDto?>
{
    public Guid FormId { get; set; }
}
