using CourseProject.Domain.Entities;
using CourseProject.Domain.Enums;
using FluentValidation;

namespace CourseProject.Infrastructure.Questions.Validators;

public class QuestionValidator : AbstractValidator<Question>
{
    public QuestionValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(question => question.TemplateId).NotEqual(Guid.Empty);
                RuleFor(question => question.Title).NotEmpty();
                RuleFor(question => question.Description).NotEmpty();
            });

        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(question => question.Title).NotEmpty();
                RuleFor(question => question.Description).NotEmpty();
            });
    }
}
