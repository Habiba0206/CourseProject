using AutoMapper;
using CourseProject.Application.Questions.Commands;
using CourseProject.Application.Questions.Models;
using CourseProject.Application.Questions.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Questions.CommandHandlers;

internal class QuestionCreateCommandHandler(
IMapper mapper,
    IQuestionService questionService) : ICommandHandler<QuestionCreateCommand, QuestionDto>
{
    public async Task<QuestionDto> Handle(QuestionCreateCommand request, CancellationToken cancellationToken)
    {
        var question = mapper.Map<Question>(request.QuestionDto);

        var createdQuestion = await questionService.CreateAsync(question, cancellationToken: cancellationToken);

        return mapper.Map<QuestionDto>(createdQuestion);
    }
}
