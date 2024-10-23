using AutoMapper;
using CourseProject.Application.Forms.Models;
using CourseProject.Application.Forms.Queries;
using CourseProject.Application.Forms.Services;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Infrastructure.Forms.QueryHandlers;

public class FormGetByIdQueryHandler(
    IMapper mapper,
    IFormService formService)
    : IQueryHandler<FormGetByIdQuery, FormDto>
{
    public async Task<FormDto> Handle(FormGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await formService.GetByIdAsync(request.FormId, cancellationToken: cancellationToken);

        return mapper.Map<FormDto>(result);
    }
}
