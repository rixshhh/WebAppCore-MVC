namespace WebApplication2.Models;

public class ExamViewModel
{
    public int ExamID { get; set; }

    public int SubjectID { get; set; }

    public string ExamType { get; set; } = string.Empty; // Midterm / Final

    public DateTime ExamDate { get; set; }

    public int MaxMarks { get; set; }

    public string SubjectName { get; set; }
}