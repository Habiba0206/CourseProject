using AutoMapper;
using CourseProject.Application.Templates.Commands;
using CourseProject.Application.Templates.Models;
using CourseProject.Application.Templates.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Templates.CommandHandlers;

internal class TemplateCreateCommandHandler(
    IMapper mapper,
    ITemplateService templateService) : ICommandHandler<TemplateCreateCommand, TemplateDto>
{
    public async Task<TemplateDto> Handle(TemplateCreateCommand request, CancellationToken cancellationToken)
    {
        var template = mapper.Map<Template>(request.TemplateDto);

        var createdTemplate = await templateService.CreateAsync(template, cancellationToken: cancellationToken);

        return mapper.Map<TemplateDto>(createdTemplate);
    }
}