namespace WebApplication2.Models;

public class CourseViewModel
{
    public required int CourseID { get; set; }
    public required string CourseName { get; set; }
    public required string CourseCode { get; set; }
    public int DurationMonths { get; set; }
    public required decimal TotalFees { get; set; }

    public DateTime CreatedAt { get; set; }
    public List<string> Subjects { get; set; } = new();
}