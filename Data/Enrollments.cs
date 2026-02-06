using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data;

public class Enrollments
{
    [Key] public int EnrollmentID { get; set; }

    public int StudentID { get; set; }
    public int CourseID { get; set; }
    public required string Status { get; set; }
}