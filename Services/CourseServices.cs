using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class CourseServices
{
    private readonly AppDbContext _DbContext;

    public CourseServices(AppDbContext DbContext)
    {
        _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
    }

    public IEnumerable<CourseViewModel> GetCourses()
    {
        var course = _DbContext.Courses
            .GroupJoin(
                _DbContext.Subjects,
                c => c.CourseID,
                s => s.CourseID,
                (c, subjects) => new CourseViewModel
                {
                    CourseID = c.CourseID,
                    CourseName = c.CourseName,
                    CourseCode = c.CourseCode,
                    DurationMonths = c.DurationMonths,
                    TotalFees = c.TotalFees,
                    CreatedAt = c.CreatedAt,
                    Subjects = subjects
                        .Select(s => s.SubjectName)
                        .ToList()
                })
            .OrderBy(c => c.CourseName)
            .ToList();
        return course;
    }
}