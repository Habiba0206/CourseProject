using CourseProject.Domain.Entities;
using FluentValidation;

namespace CourseProject.Infrastructure.Templates.Validators;

public class TemplateValidator : AbstractValidator<Template>
{
    public TemplateValidator()
    {
        RuleFor(template => template.Title).NotEmpty().MinimumLength(5);
        RuleFor(template => template.Description).NotEmpty().MinimumLength(5);
    }
}
