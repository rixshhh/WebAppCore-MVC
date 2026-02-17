using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class EnrollmentServices
{
    private readonly AppDbContext _DbContext;
    private readonly ILogger<EnrollmentServices> _logger;

    public EnrollmentServices(AppDbContext DbContext, ILogger<EnrollmentServices> logger)
    {
        _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
        _logger = logger;
    }

    public IEnumerable<StudentEnrollmentViewModel> GetEnrolledStudents()
    {
        var data =
            (from s in _DbContext.Students
                join e in _DbContext.Enrollments on s.StudentID equals e.StudentID
                join c in _DbContext.Courses on e.CourseID equals c.CourseID
                join sub in _DbContext.Subjects on c.CourseID equals sub.CourseID
                select new
                {
                    StudentId = s.StudentID,
                    StudentName = s.FirstName + " " + s.LastName,
                    CourseId = c.CourseID,
                    c.CourseName,
                    sub.SubjectName,
                    sub.SubjectCode
                })
            .AsEnumerable() // Prevent EF translation error
            .GroupBy(x => x.StudentId)
            .Select(studentGroup => new StudentEnrollmentViewModel
            {
                StudentName = studentGroup.First().StudentName,

                Courses = studentGroup
                    .GroupBy(c => c.CourseId)
                    .Select(courseGroup => new StudentEnrollmentViewModel.CourseData
                    {
                        CourseName = courseGroup.First().CourseName,

                        Subjects = courseGroup
                            .Select(s => new StudentEnrollmentViewModel.SubjectData
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

        return data;
    }


    public IEnumerable<StudentEnrollmentViewModel>? GetEnrolledStudentList()
    {
        try
        {
            var data =
                (from s in _DbContext.Students
                    join e in _DbContext.Enrollments on s.StudentID equals e.StudentID
                    join c in _DbContext.Courses on e.CourseID equals c.CourseID
                    join sub in _DbContext.Subjects on c.CourseID equals sub.CourseID
                    select new
                    {
                        StudentId = s.StudentID,
                        StudentName = s.FirstName + " " + s.LastName,
                        CourseId = c.CourseID,
                        c.CourseName,
                        sub.SubjectName,
                        sub.SubjectCode
                    })
                .AsEnumerable() // Prevent EF translation error
                .GroupBy(x => x.StudentId)
                .Select(studentGroup => new StudentEnrollmentViewModel
                {
                    StudentName = studentGroup.First().StudentName,

                    Courses = studentGroup
                        .GroupBy(c => c.CourseId)
                        .Select(courseGroup => new StudentEnrollmentViewModel.CourseData
                        {
                            CourseName = courseGroup.First().CourseName,

                            Subjects = courseGroup
                                .Select(s => new StudentEnrollmentViewModel.SubjectData
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

            return data;
        }
        catch (ConflictException ex)
        {
            _logger.LogError(ex, "Error while displaying enrolled Students. Some conflicts occured.");
        }

        return null;
    }
}