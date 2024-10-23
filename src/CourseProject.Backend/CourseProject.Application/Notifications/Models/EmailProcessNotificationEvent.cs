using CourseProject.Application.Notifications.Events;
using CourseProject.Domain.Enums;

namespace CourseProject.Application.Notifications.Models;

public record EmailProcessNotificationEvent : ProcessNotificationEvent
{
    public EmailProcessNotificationEvent()
    {
        Type = NotificationType.Email;
    }
}