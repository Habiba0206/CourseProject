using CourseProject.Application.Templates.Commands;
using CourseProject.Application.Templates.Services;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Infrastructure.Templates.CommandHandlers;

public class TemplateDeleteByIdCommandHandler(
    ITemplateService templateService)
    : ICommandHandler<TemplateDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(TemplateDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await templateService.DeleteByIdAsync(request.TemplateId, cancellationToken: cancellationToken);

        return result is not null;
    }
}
