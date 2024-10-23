using CourseProject.Application.Forms.Models;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Forms.Commands;

public class FormUpdateCommand : ICommand<FormDto>
{
    public FormDto FormDto { get; set; }
}
