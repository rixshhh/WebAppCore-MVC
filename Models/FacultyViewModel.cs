using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class FacultyVIewModel
{
    [Key] public int FacultyID { get; set; }

    public required string FacultyName { get; set; }
    public required string Department { get; set; }

    public required DateOnly? HireDate { get; set; }
}