using CourseProject.Application.Templates.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Templates.Queries;

public class TemplateGetQuery : IQuery<ICollection<TemplateDto>>
{
    public TemplateFilter TemplateFilter { get; set; }
}

