using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class CreateFacultyRequestDTO
{
    [Required] public required string FacultyName { get; init; }
    public required string Department { get; init; }
    public required string Email { get; init; }
    public required string Phone { get; init; }
    public DateOnly? HireDate { get; init; }
    public bool IsActive { get; init; }
}