namespace WebApplication2.Models;

public class CourseSubjectViewModels
{
    public required int CourseID { get; set; }
    public required string CourseName { get; set; }
    public required string CourseCode { get; set; }
    public required decimal TotalFees { get; set; }
    public required List<string> Subjects { get; set; }
}