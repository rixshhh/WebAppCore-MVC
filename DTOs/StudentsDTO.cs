namespace WebApplication2.DTOs
{
    public sealed class StudentsDTO(
        int StudentID, int RollNumber, string FirstName, string LastName, DateOnly? DOB, string Gender,
        string Email, string Phone, string Address, DateOnly? AdmissionDate, bool IsActive, DateTime? CreatedAt
        )
    {
        public int StudentID { get; } = StudentID;

        public int RollNumber { get; } = RollNumber;

        public string FirstName { get; } = FirstName;
        public string LastName { get; } = LastName;

        public DateOnly? DOB { get; } = DOB;

        public string Gender { get; } = Gender;
        public string Email { get; } = Email;
        public string Phone { get; } = Phone;
        public string Address { get; } = Address;

        public DateOnly? AdmissionDate { get; } = AdmissionDate;
        public bool IsActive { get; } = IsActive;
        public DateTime? CreatedAt { get; } = CreatedAt;
    }
}
