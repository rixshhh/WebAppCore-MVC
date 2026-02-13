using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class FacultyServices
{
    private readonly AppDbContext _DbContext;

    public FacultyServices(AppDbContext DbContext)
    {
        _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
    }

    public IEnumerable<FacultyVIewModel> getFacultyDetails()
    {
        IReadOnlyList<FacultyVIewModel> faculty = _DbContext.Faculty
            .Select(f => new FacultyVIewModel
            {
                FacultyID = f.FacultyID,
                FacultyName = f.FacultyName,
                Department = f.Department,
                Email = f.Email,
                Phone = f.Phone,
                HireDate = f.HireDate,
                IsActive = f.IsActive
            }).ToList();

        return faculty;
    }

    public IEnumerable<FacultyVIewModel> GetAllFacultyDetails()
    {
        IReadOnlyList<FacultyVIewModel> faculty = _DbContext.Faculty
            .Select(f => new FacultyVIewModel
            {
                FacultyID = f.FacultyID,
                FacultyName = f.FacultyName,
                Email = f.Email,
                Phone = f.Phone,
                Department = f.Department,
                HireDate = f.HireDate,
                IsActive = f.IsActive
            }).ToList();

        return faculty;
    }

    public FacultyDTO? GetFacultyDetailsById(int FacultyID)
    {
        var faculty = _DbContext.Faculty.Find(FacultyID);
        if (faculty is null) return null;

        return new FacultyDTO(
            faculty.FacultyID,
            faculty.FacultyName,
            faculty.Email,
            faculty.Phone,
            faculty.Department,
            faculty.HireDate,
            faculty.IsActive
        );
    }

    public bool CreateFacultyRequest(CreateFacultyRequestDTO facultyRequest)
    {
        try
        {
            var faculty = _DbContext.Faculty.FirstOrDefault(f => f.FacultyName == facultyRequest.FacultyName);

            if (faculty is not null)
                throw new Exception($"State with code {facultyRequest.FacultyName} already exists.");

            faculty = new Faculty
            {
                FacultyName = facultyRequest.FacultyName,
                Department = facultyRequest.Department,
                Email = facultyRequest.Email,
                Phone = facultyRequest.Phone,
                HireDate = facultyRequest.HireDate,
                IsActive = facultyRequest.IsActive
            };

            _DbContext.Faculty.Add(faculty);
            _DbContext.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public FacultyDTO? UpdateFacultyRequest(int FacultyID, CreateFacultyRequestDTO facultyRequest)
    {
        try
        {
            var faculty = _DbContext.Faculty.Find(FacultyID);
            if (faculty is null) throw new Exception($"State with code {FacultyID} does not exist.");

            faculty.FacultyName = facultyRequest.FacultyName;
            faculty.Department = facultyRequest.Department;
            faculty.Email = facultyRequest.Email;
            faculty.Phone = facultyRequest.Phone;
            faculty.HireDate = facultyRequest.HireDate;
            faculty.IsActive = facultyRequest.IsActive;

            _DbContext.SaveChanges();

            return new FacultyDTO(
                faculty.FacultyID,
                faculty.FacultyName,
                faculty.Email,
                faculty.Phone,
                faculty.Department,
                faculty.HireDate,
                faculty.IsActive
            );
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}