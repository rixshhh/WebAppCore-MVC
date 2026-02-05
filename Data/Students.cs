using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data
{
    public sealed class Students
    {
        [Key]
        public int StudentID { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string Gender { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
    }
}
