using CourseProject.Application.Templates.Models;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Templates.Commands;

public class TemplateUpdateCommand : ICommand<TemplateDto>
{
    public TemplateDto TemplateDto { get; set; }
}
