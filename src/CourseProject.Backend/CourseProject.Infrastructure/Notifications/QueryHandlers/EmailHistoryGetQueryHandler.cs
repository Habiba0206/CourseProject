using AutoMapper;
using CourseProject.Application.Notifications.Models;
using CourseProject.Application.Notifications.Queries;
using CourseProject.Application.Notifications.Services;
using CourseProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Infrastructure.Notifications.QueryHandlers;

public class EmailHistoryGetQueryHandler(
    IMapper mapper,
    IEmailHistoryService emailHistoryService)
    : IQueryHandler<EmailHistoryGetQuery, ICollection<EmailHistoryDto>>
{
    public async Task<ICollection<EmailHistoryDto>> Handle(EmailHistoryGetQuery request, CancellationToken cancellationToken)
    {
        var result = await emailHistoryService.Get(
            request.EmailHistoryFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map< ICollection<EmailHistoryDto>>(result);
    }
}
