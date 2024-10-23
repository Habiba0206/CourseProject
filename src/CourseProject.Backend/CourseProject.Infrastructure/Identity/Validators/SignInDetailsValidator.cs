using CourseProject.Application.Common.Settings;
using CourseProject.Application.Identity.Models;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace CourseProject.Infrastructure.Identity.Validators;

public class SignInDetailsValidator : AbstractValidator<SignInDetails>
{
    public SignInDetailsValidator(IOptions<ValidationSettings> validationSettings)
    {
        var validationSettingsValue = validationSettings.Value;

        RuleFor(x => x.EmailAddress).NotEmpty().Matches(validationSettingsValue.EmailAddressRegexPattern);

        RuleFor(x => x.Password).NotEmpty();
    }
}