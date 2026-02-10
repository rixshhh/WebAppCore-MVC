using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data;

public sealed class Exams
{
    [Key] public required int ExamID { get; set; }

    public required int SubjectID { get; set; }

    public required string ExamType { get; set; } = string.Empty; // Midterm / Final

    public required DateTime ExamDate { get; set; }

    public required int MaxMarks { get; set; }
}