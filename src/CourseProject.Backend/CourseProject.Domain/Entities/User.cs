using CourseProject.Domain.Common.Entities;
using CourseProject.Domain.Enums;

namespace CourseProject.Domain.Entities;

public class User : AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PasswordHash { get; set; }
    public int Age { get; set; }
    public bool IsEmailAddressVerified { get; set; }
    public Role Role { get; set; }
    public UserState UserState { get; set; }
    public UserSettings? UserSettings { get; set; }
}
