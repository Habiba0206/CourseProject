using Type = CourseProject.Domain.Enums.NotificationType;

namespace CourseProject.Domain.Entities;

public class EmailTemplate : NotificationTemplate
{
    public EmailTemplate()
    {
        Type = Type.Email;
    }

    public string Subject { get; set; } = default!;
}