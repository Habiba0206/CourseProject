using AutoMapper;
using CourseProject.Application.Notifications.Models;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Notifications.Mappers;

public class NotificationHistoryMapper : Profile
{
    public NotificationHistoryMapper()
    {
        CreateMap<EmailMessage, EmailHistory>()
            .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.Template.Id))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Body));
    }
}