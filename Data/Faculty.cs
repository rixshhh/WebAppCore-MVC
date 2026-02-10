using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data;

public sealed class Faculty
{
    [Key] public required int FacultyID { get; set; }

    [StringLength(100)] public required string FacultyName { get; set; }

    [StringLength(100)] public required string Email { get; set; }

    [StringLength(15)] public required string Phone { get; set; }

    [StringLength(100)] public required string Department { get; set; }

    public required DateOnly? HireDate { get; set; }
    public required bool IsActive { get; set; }
}