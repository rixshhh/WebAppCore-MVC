using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class StudentServices
{
    private readonly AppDbContext _DbContext;
    private readonly ILogger<StudentServices> _logger;

    public StudentServices(AppDbContext DbContext, ILogger<StudentServices> logger)
    {
        _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
        _logger = logger;
    }

    public IEnumerable<StudentsViewModel> GetStudents()
    {
        IReadOnlyList<StudentsViewModel> Students = _DbContext.Students
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


    public StudentsDTO? GetStudentById(int StudentID)
    {
        var student = _DbContext.Students.Find(StudentID);
        if (student is null) return null;
        return new StudentsDTO(
            student.StudentID,
            student.RollNumber,
            student.FirstName,
            student.LastName,
            student.DOB,
            student.Gender,
            student.Email,
            student.Phone,
            student.Address,
            student.AdmissionDate,
            student.IsActive,
            student.CreatedAt
        );
    }


    public IEnumerable<StudentsDTO> GetStudentsList()
    {
        IReadOnlyList<StudentsDTO> Students = _DbContext.Students
            .Select(s => new StudentsDTO
            (
                s.StudentID,
                s.RollNumber,
                s.FirstName,
                s.LastName,
                s.DOB,
                s.Gender,
                s.Email,
                s.Phone,
                s.Address,
                s.AdmissionDate,
                s.IsActive,
                s.CreatedAt
            )).ToList();

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

        _DbContext.Students.Add(createStudent);
        _DbContext.SaveChanges();

        return true;
    }


    public StudentsDTO? CreateStudentRequest(CreateStudentRequestDTO studentRequest)
    {
        try
        {
            var student = _DbContext.Students.FirstOrDefault(s => s.RollNumber == studentRequest.RollNumber
            );

            if (student is not null)
                throw new Exception($"State with code {studentRequest.RollNumber} already exists.");

            student = new Students
            {
                RollNumber = studentRequest.RollNumber,
                FirstName = studentRequest.FirstName,
                LastName = studentRequest.LastName,
                DOB = studentRequest.DOB,
                Gender = studentRequest.Gender,
                Email = studentRequest.Email,
                Phone = studentRequest.Phone,
                Address = studentRequest.Address,
                AdmissionDate = studentRequest.AdmissionDate,
                IsActive = studentRequest.IsActive,
                CreatedAt = DateTime.UtcNow.Date
            };

            _DbContext.Students.Add(student);
            _DbContext.SaveChanges();

            return new StudentsDTO(
                student.StudentID,
                student.RollNumber,
                student.FirstName,
                student.LastName,
                student.DOB,
                student.Gender,
                student.Email,
                student.Phone,
                student.Address,
                student.AdmissionDate,
                student.IsActive,
                student.CreatedAt
            );
        }
        catch (ConflictException ex)
        {
            _logger.LogError(ex, "Error while creating a state with name {RollNumber}. Some conflicts occured.",
                studentRequest.RollNumber);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex,
                "Error while creating a state with name {RollNumber}. Problem in execution of sql query.",
                studentRequest.RollNumber);
        }
        catch (Exception e)
        {
            // _logger.LogError(e, "Error while creating a state with name {stateName} {code}.", request.Name,
            //     request.Code);
            _logger.LogError(e, "Error while creating a state with name {@state}.", studentRequest);
        }

        return null;
    }


    public StudentsDTO? UpdateStudent(int StudentID, CreateStudentRequestDTO studentRequest)
    {
        try
        {
            var student = _DbContext.Students.Find(StudentID);

            if (student is null) return null;

            // Roll Number
            var rollNumberExists = _DbContext.Students
                .Any(s => s.RollNumber == studentRequest.RollNumber && s.StudentID != StudentID);

            if (rollNumberExists) throw new Exception($"Roll number '{studentRequest.RollNumber}' already exists.");

            // Email
            var emailExists = _DbContext.Students
                .Any(s => s.Email == studentRequest.Email && s.StudentID != StudentID);

            if (emailExists) throw new Exception($"Email '{studentRequest.Email}' already exists.");


            student.RollNumber = studentRequest.RollNumber;
            student.FirstName = studentRequest.FirstName;
            student.LastName = studentRequest.LastName;
            student.DOB = studentRequest.DOB;
            student.Gender = studentRequest.Gender;
            student.Email = studentRequest.Email;
            student.Phone = studentRequest.Phone;
            student.Address = studentRequest.Address;
            student.AdmissionDate = studentRequest.AdmissionDate;
            student.IsActive = studentRequest.IsActive;
            student.CreatedAt = DateTime.UtcNow.Date;

            _DbContext.SaveChanges();

            return new StudentsDTO(
                student.StudentID,
                student.RollNumber,
                student.FirstName,
                student.LastName,
                student.DOB,
                student.Gender,
                student.Email,
                student.Phone,
                student.Address,
                student.AdmissionDate,
                student.IsActive,
                student.CreatedAt
            );
        }
        catch (Exception)
        {
            return null;
        }
    }


    public StudentsDTO? DeleteStudent(int StudentID)
    {
        try
        {
            var student = _DbContext.Students.FirstOrDefault(s => s.StudentID == StudentID);

            if (student is null)
                throw new ConflictException($"Cannot find this StudentID {StudentID}");

            _DbContext.Students.Remove(student);

            _DbContext.SaveChanges();

            return new StudentsDTO(
                student.StudentID,
                student.RollNumber,
                student.FirstName,
                student.LastName,
                student.DOB,
                student.Gender,
                student.Email,
                student.Phone,
                student.Address,
                student.AdmissionDate,
                student.IsActive,
                student.CreatedAt
            );
        }
        catch (ConflictException ex)
        {
            _logger.LogError(ex, "Error while creating a state with StudentID {StudentID}. Some conflicts occured.",
                StudentID);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex,
                "Database error while deleting student with ID {StudentID}", StudentID);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unexpected error while deleting student with ID {StudentID}", StudentID);
        }

        return null;
    }

    public StudentsDTO? PatchStudent(int StudentID, PatchStudentStatusRequest patchRequest)
    {
        try
        {
            var student = _DbContext.Students.Find(StudentID);

            if (student is null)
                throw new ConflictException($"Cannot find this StudentID {StudentID}.Please Enter valid StudentID.");

            _DbContext.Entry(student).CurrentValues.SetValues(patchRequest);

            _DbContext.SaveChanges();

            return new StudentsDTO(
                student.StudentID,
                student.RollNumber,
                student.FirstName,
                student.LastName,
                student.DOB,
                student.Gender,
                student.Email,
                student.Phone,
                student.Address,
                student.AdmissionDate,
                student.IsActive,
                student.CreatedAt
            );
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex,
                "Database error while patching student {StudentID}", StudentID);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unexpected error while patching student with StudentID {StudentID}", StudentID);
        }

        return null;
    }
}