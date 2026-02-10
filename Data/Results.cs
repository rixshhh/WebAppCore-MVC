using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data;

public class Results
{
    [Key] public required int ResultID { get; set; }

    public required int StudentID { get; set; }

    public required int ExamID { get; set; }

    public required decimal MarksObtained { get; set; }

    public string? Grade { get; set; } // Nullable (optional)
}