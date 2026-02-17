using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class CourseServices
{
    private readonly AppDbContext _DbContext;
    private readonly ILogger<CourseServices> _logger;
    public CourseServices(AppDbContext DbContext, ILogger<CourseServices> logger)
    {
        _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
        _logger = logger;
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

    public IEnumerable<CourseViewModel> GetCoursesList()
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
            .OrderBy(c => c.CourseID)
            .ToList();
        return course;
    }

    public CourseDTO? GetCourseById(int CourseID)
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
        .FirstOrDefault(c => c.CourseID == CourseID);

        if (course is null) return null;

        return new CourseDTO(
            course.CourseID,
            course.CourseCode,
            course.CourseName,
            course.DurationMonths,
            course.TotalFees,
            course.CreatedAt,
            course.Subjects
        );
    }
}