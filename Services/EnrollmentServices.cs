using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class EnrollmentServices
{
    private readonly AppDbContext DbContext = new();

    public IEnumerable<StudentEnrollmentViewModel> GetEnrolledStudents()
    {
        var data =
            (from s in DbContext.Students
                join e in DbContext.Enrollments on s.StudentID equals e.StudentID
                join c in DbContext.Courses on e.CourseID equals c.CourseID
                join sub in DbContext.Subjects on c.CourseID equals sub.CourseID
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
}