using AutoMapper;
using CourseProject.Application.Answers.Commands;
using CourseProject.Application.Answers.Models;
using CourseProject.Application.Answers.Services;
using CourseProject.Application.Forms.Commands;
using CourseProject.Application.Forms.Models;
using CourseProject.Application.Forms.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Forms.CommandHandlers;

public class FormUpdateCommandHandler(
    IMapper mapper,
    IFormService formService) : ICommandHandler<FormUpdateCommand, FormDto>
{
    public async Task<FormDto> Handle(FormUpdateCommand request, CancellationToken cancellationToken)
    {
        var form = mapper.Map<Form>(request.FormDto);

        var createdForm = await formService.UpdateAsync(form, cancellationToken: cancellationToken);

        return mapper.Map<FormDto>(createdForm);
    }
}

