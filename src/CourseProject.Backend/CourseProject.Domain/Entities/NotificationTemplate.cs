using CourseProject.Domain.Common.Entities;
using CourseProject.Domain.Enums;

namespace CourseProject.Domain.Entities;

public abstract class NotificationTemplate : IEntity
{
    public NotificationType Type { get; set; }

    public NotificationTemplateType TemplateType { get; set; }

    public string Content { get; set; } = default!;

    public IList<NotificationHistory> Histories { get; set; } = new List<NotificationHistory>();
    public Guid Id { get; set; }
}