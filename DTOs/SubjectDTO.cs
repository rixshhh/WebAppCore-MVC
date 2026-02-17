namespace WebApplication2.DTOs;

public class SubjectDTO(
    int SubjectID,
    string SubjectName
)
{
    public int SubjectID { get; } = SubjectID;

    public string SubjectName { get; } = SubjectName;
}