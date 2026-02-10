namespace WebApplication2.Models;

public class StudentEnrollmentViewModel
{
    public string StudentName { get; set; }

    public List<CourseData> Courses { get; set; } = new();

    public class CourseData
    {
        public string CourseName { get; set; }

        public List<SubjectData> Subjects { get; set; } = new();
    }

    public class SubjectData
    {
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
    }
}