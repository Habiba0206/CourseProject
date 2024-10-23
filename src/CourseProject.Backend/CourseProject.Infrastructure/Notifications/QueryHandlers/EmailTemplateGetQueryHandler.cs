using AutoMapper;
using CourseProject.Application.Notifications.Models;
using CourseProject.Application.Notifications.Queries;
using CourseProject.Application.Notifications.Services;
using CourseProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Infrastructure.Notifications.QueryHandlers;

public class EmailTemplateGetQueryHandler(
    IMapper mapper,
    IEmailTemplateService emailTemplateService)
    : IQueryHandler<EmailTemplateGetQuery, ICollection<EmailTemplateDto>>
{
    public async Task<ICollection<EmailTemplateDto>> Handle(EmailTemplateGetQuery request, CancellationToken cancellationToken)
    {
        var result = await emailTemplateService.Get(
            request.EmailTemplateFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<EmailTemplateDto>>(result);
    }
}
