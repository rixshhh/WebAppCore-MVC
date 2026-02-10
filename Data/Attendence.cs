using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data;

public sealed class Attendence
{
    [Key][Required] public int AttendanceID { get; set; }

    [Required] public int StudentID { get; set; }
    [Required] public int SubjectID { get; set; }

    [Required] public DateOnly AttendanceDate { get; set; }

    [Required] public string Status { get; set; } = "Present";

    [Required] public int MarkedBy { get; set; } // FacultyID
}