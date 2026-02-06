using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class StudentEnrolledController : Controller
{
    public IActionResult Index()
    {
        AppDbContext DbContext = new();
        var data =
            (from s in DbContext.Students
                join e in DbContext.Enrollments on s.StudentID equals e.StudentID
                join c in DbContext.Courses on e.CourseID equals c.CourseID
                join sub in DbContext.Subjects on e.CourseID equals sub.CourseID
                select new
                {
                    StudentName = s.FirstName + " " + s.LastName,
                    c.CourseName,
                    sub.SubjectName,
                    sub.SubjectCode
                }).ToList();

        var result = data
            .GroupBy(x => x.StudentName)
            .Select(student => new StudentEnrollmentViewModels
            {
                StudentName = student.Key,
                Courses = student
                    .GroupBy(c => c.CourseName)
                    .Select(course => new StudentEnrollmentViewModels.CourseInfo
                    {
                        CourseName = course.Key,
                        Subjects = course
                            .Select(s => new StudentEnrollmentViewModels.SubjectInfo
                            {
                                SubjectName = s.SubjectName,
                                SubjectCode = s.SubjectCode
                            })
                            .Distinct()
                            .ToList()
                    })
                    .ToList()
            })
            .OrderBy(x => x.StudentName)
            .ToList();

        return View(result);
    }
}