using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class AttendenceServices
{
    public IEnumerable<AttendenceViewModel> GetAttendenceDetails()
    {
        AppDbContext DbContext = new();

        var attendanceData =
            (from a in DbContext.Attendence
                join s in DbContext.Students
                    on a.StudentID equals s.StudentID
                join sub in DbContext.Subjects
                    on a.SubjectID equals sub.SubjectID
                join f in DbContext.Faculty
                    on a.MarkedBy equals f.FacultyID
                select new
                {
                    StudentName = s.FirstName + " " + s.LastName,
                    sub.SubjectName,
                    a.AttendanceDate,
                    a.Status,
                    MarkedBy = f.FacultyName
                }).ToList();

        var result = attendanceData
            .GroupBy(x => new { x.SubjectName, x.AttendanceDate, x.MarkedBy })
            .Select(g => new AttendenceViewModel
            {
                SubjectName = g.Key.SubjectName,
                AttendanceDate = g.Key.AttendanceDate,
                MarkedBy = g.Key.MarkedBy,
                PresentStudents = g.Where(x => x.Status == "Present")
                    .Select(x => x.StudentName)
                    .Distinct()
                    .ToList(),
                AbsentStudents = g.Where(x => x.Status == "Absent")
                    .Select(x => x.StudentName)
                    .Distinct()
                    .ToList()
            })
            .OrderBy(x => x.SubjectName)
            .ThenBy(x => x.AttendanceDate)
            .ToList();

        return result;
    }
}