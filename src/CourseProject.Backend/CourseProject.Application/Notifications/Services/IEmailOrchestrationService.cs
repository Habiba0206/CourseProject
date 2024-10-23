using CourseProject.Application.Notifications.Models;
using CourseProject.Domain.Common.Exceptions;

namespace CourseProject.Application.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(EmailProcessNotificationEvent @event, CancellationToken cancellationToken = default);
}
