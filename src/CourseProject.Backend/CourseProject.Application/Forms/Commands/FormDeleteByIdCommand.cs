using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Forms.Commands;

public class FormDeleteByIdCommand : ICommand<bool>
{
    public Guid FormId { get; set; }
}
