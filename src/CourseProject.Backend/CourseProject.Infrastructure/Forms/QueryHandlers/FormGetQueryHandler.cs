using AutoMapper;
using CourseProject.Application.Forms.Models;
using CourseProject.Application.Forms.Queries;
using CourseProject.Application.Forms.Services;
using CourseProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Infrastructure.Forms.QueryHandlers;

internal class FormGetQueryHandler(
    IMapper mapper,
    IFormService formService)
    : IQueryHandler<FormGetQuery, ICollection<FormDto>>
{
    public async Task<ICollection<FormDto>> Handle(FormGetQuery request, CancellationToken cancellationToken)
    {
        var result = await formService.Get(
            request.FormFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<FormDto>>(result);
    }
}
