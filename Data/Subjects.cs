using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data;

public sealed class Subjects
{
    [Key] public int SubjectID { get; set; }

    public required string SubjectName { get; set; }
    public required string SubjectCode { get; set; }
    public int CourseID { get; set; }
    public required byte Credits { get; set; }
}