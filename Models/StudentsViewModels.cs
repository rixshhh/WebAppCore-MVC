using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class StudentsViewModels
    {
        [Key]
        public int StudentID { get; set; }

        public required int RollNumber { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required DateOnly? DOB { get; set; }

        public required string Gender { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }

        public required DateOnly? AdmissionDate { get; set; }
        public required bool IsActive { get; set; }
        public required DateTime? CreatedAt { get; set; }

        public required DateTime? UpdatedAt { get; set; }
    }
}
