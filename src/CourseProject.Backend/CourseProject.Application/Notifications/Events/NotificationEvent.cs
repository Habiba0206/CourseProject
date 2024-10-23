using CourseProject.Domain.Common.Events;

namespace CourseProject.Application.Notifications.Events;

public record NotificationEvent : EventBase
{
    public Guid SenderUserId { get; set; }

    public Guid ReceiverUserId { get; set; }
}
