using CourseProject.Application.Templates.Models;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Templates.Commands;

public class TemplateCreateCommand : ICommand<TemplateDto>
{
    public TemplateDto TemplateDto { get; set; }
}
