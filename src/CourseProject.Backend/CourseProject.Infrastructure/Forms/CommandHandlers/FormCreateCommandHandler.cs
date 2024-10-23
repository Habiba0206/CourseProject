using AutoMapper;
using CourseProject.Application.Forms.Commands;
using CourseProject.Application.Forms.Models;
using CourseProject.Application.Forms.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Forms.CommandHandlers;

public class FormCreateCommandHandler(
    IMapper mapper,
    IFormService formService) : ICommandHandler<FormCreateCommand, FormDto>
{
    public async Task<FormDto> Handle(FormCreateCommand request, CancellationToken cancellationToken)
    {
        var form = mapper.Map<Form>(request.FormDto);

        var createdForm = await formService.CreateAsync(form, cancellationToken: cancellationToken);

        return mapper.Map<FormDto>(createdForm);
    }
}
