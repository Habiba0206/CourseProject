using AutoMapper;
using CourseProject.Application.Templates.Commands;
using CourseProject.Application.Templates.Models;
using CourseProject.Application.Templates.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Templates.CommandHandlers;

public class TemplateUpdateCommandHandler(
    IMapper mapper,
    ITemplateService templateService) : ICommandHandler<TemplateUpdateCommand, TemplateDto>
{
    public async Task<TemplateDto> Handle(TemplateUpdateCommand request, CancellationToken cancellationToken)
    {
        var template = mapper.Map<Template>(request.TemplateDto);

        var createdTemplate = await templateService.UpdateAsync(template, cancellationToken: cancellationToken);

        return mapper.Map<TemplateDto>(createdTemplate);
    }
}
