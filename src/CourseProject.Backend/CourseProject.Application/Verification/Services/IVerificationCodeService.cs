using CourseProject.Domain.Enums;

namespace CourseProject.Application.Verification.Services;

public interface IVerificationCodeService
{
    ValueTask<VerificationType?> GetVerificationTypeAsync(string code, CancellationToken cancellationToken = default);
}
