using WebApplication2.Data;
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
                HireDate = f.HireDate
            }).ToList();

        return faculty;
    }
}