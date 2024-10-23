using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Templates.Commands;

public class TemplateDeleteByIdCommand : ICommand<bool>
{
    public Guid TemplateId { get; set; }
}

