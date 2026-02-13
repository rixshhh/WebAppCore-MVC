using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class PatchStudentStatusRequest
{
    [Required] public required bool IsActive { get; init; }
}