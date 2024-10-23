using AutoMapper;
using CourseProject.Application.Notifications.Models;

namespace CourseProject.Infrastructure.Notifications.Mappers;

public class NotificationMessageMapper : Profile
{
    public NotificationMessageMapper()
    {
        CreateMap<EmailProcessNotificationEvent, EmailMessage>();
    }
}