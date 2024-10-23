using CourseProject.Domain.Entities;
using CourseProject.Domain.Enums;
using FluentValidation;

namespace CourseProject.Infrastructure.Answers.Validators;
public class AnswerValidator : AbstractValidator<Answer>
{
    public AnswerValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () => 
            {
                RuleFor(answer => answer.FormId).NotEqual(Guid.Empty);
                RuleFor(answer => answer.QuestionId).NotEqual(Guid.Empty);
                RuleFor(answer => answer.Value).NotEmpty().MinimumLength(2);
            });

        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(answer => answer.Value).NotEmpty().MinimumLength(2);
            });
    }
}
