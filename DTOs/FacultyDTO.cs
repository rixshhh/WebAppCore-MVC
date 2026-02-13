namespace WebApplication2.DTOs;

public sealed class FacultyDTO(
    int FacultyID,
    string FacultyName,
    string Email,
    string Phone,
    string Department,
    DateOnly? HireDate,
    bool IsActive
)
{
    public int FacultyID { get; } = FacultyID;

    public string FacultyName { get; } = FacultyName;

    public string Email { get; } = Email;

    public string Phone { get; } = Phone;

    public string Department { get; } = Department;

    public DateOnly? HireDate { get; } = HireDate;
    public bool IsActive { get; } = IsActive;
}