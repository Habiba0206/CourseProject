using CourseProject.Application.Notifications.Events;
using CourseProject.Application.Notifications.Models;
using CourseProject.Domain.Common.Exceptions;
using CourseProject.Domain.Entities;

namespace CourseProject.Application.Notifications.Services;

public interface INotificationAggregatorService
{
    public ValueTask<FuncResult<bool>> SendAsync(ProcessNotificationEvent processNotificationEvent, CancellationToken cancellationToken = default);

    public ValueTask<IList<NotificationTemplate>> GetTemplatesByFilterAsync(
        NotificationTemplateFilter notificationTemplateFilter,
        CancellationToken cancellationToken = default
        );
}
