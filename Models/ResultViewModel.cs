using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Models;

public class ResultViewModel
{
    [Key] public int ResultID { get; set; }

    public int StudentID { get; set; }

    public int ExamID { get; set; }

    public decimal MarksObtained { get; set; }

    public string? Grade { get; set; } // Nullable (optional)

    public string? StudentName { get; set; }
    public string? SubjectName { get; set; }

    public int MaxMarks { get; set; }


    public List<SelectListItem> StudentsList { get; set; }
    public List<SelectListItem> SubjectsList { get; set; }
}