using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class FacultyServices
{
    public IEnumerable<FacultyVIewModel> getFacultyDetails()
    {
        AppDbContext DbContext = new();

        IReadOnlyList<FacultyVIewModel> faculty = DbContext.Faculty
            .Select(f => new FacultyVIewModel
            {
                FacultyID = f.FacultyID,
                FacultyName = f.FacultyName,
                Department = f.Department,
                HireDate = f.HireDate
            }).ToList();

        return faculty;
    }
}