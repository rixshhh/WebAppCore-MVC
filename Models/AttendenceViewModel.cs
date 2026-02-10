namespace WebApplication2.Models;

public class AttendenceViewModel
{
    public string? SubjectName { get; set; }
    public DateOnly AttendanceDate { get; set; }
    public string? MarkedBy { get; set; }

    public List<string> PresentStudents { get; set; }
    public List<string> AbsentStudents { get; set; }
}