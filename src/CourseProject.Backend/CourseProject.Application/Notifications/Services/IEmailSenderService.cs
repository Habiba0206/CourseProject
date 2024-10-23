using CourseProject.Application.Notifications.Models;

namespace CourseProject.Application.Notifications.Services;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}
