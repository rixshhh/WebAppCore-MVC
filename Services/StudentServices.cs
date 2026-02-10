using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class StudentServices
{
    private readonly AppDbContext DbContext = new();

    public IEnumerable<StudentsViewModel> GetStudents()
    {
        IReadOnlyList<StudentsViewModel> Students = DbContext.Students
            .Select(s => new StudentsViewModel
            {
                StudentID = s.StudentID,
                RollNumber = s.RollNumber,
                FirstName = s.FirstName,
                LastName = s.LastName,
                DOB = s.DOB,
                Gender = s.Gender,
                Email = s.Email,
                Phone = s.Phone,
                Address = s.Address,
                AdmissionDate = s.AdmissionDate,
                IsActive = s.IsActive,
                CreatedAt = s.CreatedAt
            }).ToList();

        return Students;
    }

    public bool CreateStudent(StudentsViewModel student)
    {
        var createStudent = new Students
        {
            RollNumber = student.RollNumber,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DOB = student.DOB,
            Gender = student.Gender,
            Email = student.Email,
            Phone = student.Phone,
            Address = student.Address,
            AdmissionDate = student.AdmissionDate,
            IsActive = student.IsActive,
            CreatedAt = DateTime.UtcNow.Date
        };

        DbContext.Students.Add(createStudent);
        DbContext.SaveChanges();

        return true;
    }
}