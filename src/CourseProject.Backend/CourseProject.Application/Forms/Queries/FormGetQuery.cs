using CourseProject.Application.Forms.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Forms.Queries;

public class FormGetQuery : IQuery<ICollection<FormDto>>
{
    public FormFilter FormFilter { get; set; }
}
