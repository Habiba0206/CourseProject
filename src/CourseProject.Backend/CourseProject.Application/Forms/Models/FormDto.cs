namespace CourseProject.Application.Forms.Models;

public class FormDto
{
    public Guid? Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TemplateId { get; set; }
    public DateTime DateSubmitted { get; set; }
}
