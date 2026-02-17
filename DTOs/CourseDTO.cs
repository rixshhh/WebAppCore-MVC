namespace WebApplication2.DTOs;

public class CourseDTO(
    int CourseID,
    string CourseName,
    string CourseCode,
    int DurationMonths,
    decimal TotalFees,
    DateTime CreatedAt,
    List<string> Subjects
)
{
    public int CourseID { get; } = CourseID;

    public string CourseName { get; } = CourseName;

    public string CourseCode { get; } = CourseCode;

    public int DurationMonths { get; } = DurationMonths;

    public decimal TotalFees { get; } = TotalFees;

    public DateTime CreatedAt { get; } = CreatedAt;

    public List<string> Subjects { get; } = Subjects;
}