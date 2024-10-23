using AutoMapper;
using CourseProject.Application.Answers.Commands;
using CourseProject.Application.Answers.Models;
using CourseProject.Application.Answers.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Answers.CommandHandlers;

public class AnswerCreateCommandHandler(
    IMapper mapper,
    IAnswerService answerService) : ICommandHandler<AnswerCreateCommand, AnswerDto>
{
    public async Task<AnswerDto> Handle(AnswerCreateCommand request, CancellationToken cancellationToken)
    {
        var answer = mapper.Map<Answer>(request.AnswerDto);

        var createdAnswer = await answerService.CreateAsync(answer, cancellationToken: cancellationToken);

        return mapper.Map<AnswerDto>(createdAnswer);
    }
}
