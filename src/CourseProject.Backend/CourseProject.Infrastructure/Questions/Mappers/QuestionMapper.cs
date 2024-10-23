using AutoMapper;
using CourseProject.Application.Questions.Models;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Questions.Mappers;

public class QuestionMapper : Profile
{
    public QuestionMapper()
    {
        CreateMap<Form, QuestionDto>().ReverseMap();
    }
}
