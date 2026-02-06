namespace WebApplication2.Models;

public class StudentEnrollmentViewModels
{
    public required string StudentName { get; set; }
    public List<CourseInfo> Courses { get; set; } = new();

    public class CourseInfo
    {
        public required string CourseName { get; set; }
        public List<SubjectInfo> Subjects { get; set; } = new();
    }

    public class SubjectInfo
    {
        public required string SubjectName { get; set; }
        public required string SubjectCode { get; set; }
    }
}