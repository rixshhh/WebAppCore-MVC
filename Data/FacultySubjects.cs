using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data;

public class FacultySubjects
{
    [Key] public required int FacultySubjectsID { get; set; }

    public required int FacultyID { get; set; }
    public required int SubjectID { get; set; }
    public required DateOnly? AssignedDate { get; set; }
}