using CourseProject.Application.Templates.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Templates.Queries;

public class TemplateGetByIdQuery : IQuery<TemplateDto?>
{
    public Guid TemplateId { get; set; }
}
