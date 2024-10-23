using AutoMapper;
using CourseProject.Application.Notifications.Events;
using CourseProject.Application.Notifications.Models;

namespace CourseProject.Infrastructure.Notifications.Mappers;

public class NotificationRequestMapper : Profile
{
    public NotificationRequestMapper()
    {
        CreateMap<ProcessNotificationEvent, EmailProcessNotificationEvent>();
    }
}