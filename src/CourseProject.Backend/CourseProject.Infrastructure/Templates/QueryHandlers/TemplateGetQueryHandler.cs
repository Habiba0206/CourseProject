using AutoMapper;
using CourseProject.Application.Templates.Models;
using CourseProject.Application.Templates.Queries;
using CourseProject.Application.Templates.Services;
using CourseProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Infrastructure.Templates.QueryHandlers;

public class TemplateGetQueryHandler(
    IMapper mapper,
    ITemplateService templateService)
    : IQueryHandler<TemplateGetQuery, ICollection<TemplateDto>>
{
    public async Task<ICollection<TemplateDto>> Handle(TemplateGetQuery request, CancellationToken cancellationToken)
    {
        var result = await templateService.Get(
            request.TemplateFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<TemplateDto>>(result);
    }
}
