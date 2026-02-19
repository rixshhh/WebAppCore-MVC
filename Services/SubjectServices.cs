using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class SubjectServices
{
    private readonly AppDbContext _DbContext;
    private readonly ILogger<SubjectServices> _logger;

    public SubjectServices(AppDbContext DbContext, ILogger<SubjectServices> logger)
    {
        _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public IEnumerable<SubjectViewModel> GetSubjects()
    {
        var subjects = (
         from c in _DbContext.Courses
         join s in _DbContext.Subjects
            on c.CourseID equals s.CourseID
         select new
         {
             s.SubjectID,
             c.CourseName,
             s.SubjectCode,
             s.SubjectName,
             s.Credits
         })
        .Select(s => new SubjectViewModel
        {
            SubjectID = s.SubjectID,
            CourseName = s.CourseName,
            SubjectCode = s.SubjectCode,
            SubjectName = s.SubjectName,
            Credits = s.Credits
        }).ToList();

        return subjects;
    }
}