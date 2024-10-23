namespace CourseProject.Application.Templates.Models;

public class TemplateDto
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsPublic { get; set; }
}
