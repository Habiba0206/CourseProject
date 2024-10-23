using AutoMapper;
using CourseProject.Application.Forms.Models;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Forms.Mappers;

public class FormMapper : Profile
{
    public FormMapper()
    {
        CreateMap<Form, FormDto>().ReverseMap();
    }
}
