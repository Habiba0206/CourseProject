using AutoMapper;
using CourseProject.Application.Answers.Commands;
using CourseProject.Application.Answers.Models;
using CourseProject.Application.Answers.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Answers.CommandHandlers;

public class AnswerUpdateCommandHandler(
    IMapper mapper,
    IAnswerService answerService) : ICommandHandler<AnswerUpdateCommand, AnswerDto>
{
    public async Task<AnswerDto> Handle(AnswerUpdateCommand request, CancellationToken cancellationToken)
    {
        var answer = mapper.Map<Answer>(request.AnswerDto);

        var createdAnswer = await answerService.UpdateAsync(answer, cancellationToken: cancellationToken);

        return mapper.Map<AnswerDto>(createdAnswer);
    }
}
