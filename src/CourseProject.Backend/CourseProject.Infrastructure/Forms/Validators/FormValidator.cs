using CourseProject.Domain.Entities;
using CourseProject.Domain.Enums;
using FluentValidation;

namespace CourseProject.Infrastructure.Forms.Validators;

public class FormValidator : AbstractValidator<Form>
{
    public FormValidator()
    {
        RuleFor(form => form.UserId).NotEqual(Guid.Empty);
        RuleFor(form => form.TemplateId).NotEqual(Guid.Empty);
        RuleFor(form => form.DateSubmitted).LessThanOrEqualTo(DateTime.Now);
    }
}
