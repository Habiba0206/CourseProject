using AutoMapper;
using CourseProject.Application.Answers.Models;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Answers.Mappers;

public class AnswerMapper : Profile
{
    public AnswerMapper()
    {
        CreateMap<Answer, AnswerDto>().ReverseMap();
    }
}
