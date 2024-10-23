using AutoMapper;
using CourseProject.Application.Answers.Commands;
using CourseProject.Application.Answers.Models;
using CourseProject.Application.Answers.Services;
using CourseProject.Application.Questions.Commands;
using CourseProject.Application.Questions.Models;
using CourseProject.Application.Questions.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Questions.CommandHandlers;

public class QuestionUpdateCommandHandler(
IMapper mapper,
    IQuestionService questionService) : ICommandHandler<QuestionUpdateCommand, QuestionDto>
{
    public async Task<QuestionDto> Handle(QuestionUpdateCommand request, CancellationToken cancellationToken)
    {
        var question = mapper.Map<Question>(request.QuestionDto);

        var createdQuestion = await questionService.UpdateAsync(question, cancellationToken: cancellationToken);

        return mapper.Map<QuestionDto>(createdQuestion);
    }
}
