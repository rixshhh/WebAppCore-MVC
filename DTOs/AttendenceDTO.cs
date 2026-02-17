namespace WebApplication2.DTOs
{
    public class AttendenceDTO(
        int AttendanceID,
        int StudentID,
        int SubjectID,
        DateOnly AttendanceDate,
        string Status,
        int MarkedBy
    )
    {
        public int AttendanceID { get; } = AttendanceID;

        public int StudentID { get; } = StudentID;
        public int SubjectID { get; } = SubjectID;

        public DateOnly AttendanceDate { get; } = AttendanceDate;

        public string Status { get; } = Status;

        public int MarkedBy { get; } = MarkedBy;
    }
}
