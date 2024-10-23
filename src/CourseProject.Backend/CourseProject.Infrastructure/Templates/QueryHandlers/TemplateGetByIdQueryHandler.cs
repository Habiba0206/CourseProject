using AutoMapper;
using CourseProject.Application.Templates.Models;
using CourseProject.Application.Templates.Queries;
using CourseProject.Application.Templates.Services;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Infrastructure.Templates.QueryHandlers;

public class TemplateGetByIdQueryHandler(
    IMapper mapper,
    ITemplateService templateService)
    : IQueryHandler<TemplateGetByIdQuery, TemplateDto>
{
    public async Task<TemplateDto> Handle(TemplateGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await templateService.GetByIdAsync(request.TemplateId, cancellationToken: cancellationToken);

        return mapper.Map<TemplateDto>(result);
    }
}
