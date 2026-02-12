using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class CreateStudentRequestDTO
{
    [Required] public int RollNumber { get; init; }

    [Required] public required string FirstName { get; init; }

    [Required] public required string LastName { get; init; }

    [Required] public required DateOnly? DOB { get; init; }

    [Required] public required string Gender { get; init; }

    [Required] public required string Email { get; init; }

    [Required] public required string Phone { get; init; }

    [Required] public required string Address { get; init; }


    [Required] public required DateOnly? AdmissionDate { get; init; }

    [Required] public required bool IsActive { get; init; }

    [Required] public required DateTime? CreatedAt { get; init; }
}