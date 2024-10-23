using AutoMapper;
using CourseProject.Application.Templates.Models;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Templates.Mappers;

public class TemplateMapper : Profile
{
    public TemplateMapper()
    {
        CreateMap<Template, TemplateDto>().ReverseMap();
    }
}
