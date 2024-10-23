using CourseProject.Application.Forms.Commands;
using CourseProject.Application.Forms.Services;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Infrastructure.Forms.CommandHandlers;

public class FormDeleteByIdCommandHandler(
    IFormService formService)
    : ICommandHandler<FormDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(FormDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await formService.DeleteByIdAsync(request.FormId, cancellationToken: cancellationToken);

        return result is not null;
    }
}
