using CourseProject.Application.Notifications.Models;

namespace CourseProject.Application.Notifications.Events;

public record SendNotificationEvent : NotificationEvent
{
    public NotificationMessage Message { get; set; } = default!;
}
