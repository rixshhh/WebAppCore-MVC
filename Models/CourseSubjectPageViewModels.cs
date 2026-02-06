using WebApplication2.Data;

namespace WebApplication2.Models;

public class CourseSubjectPageViewModels
{
    public required List<Courses> Courses { get; set; }
    public required List<CourseSubjectViewModels> CourseSubjects { get; set; }
}