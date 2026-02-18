using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class ExamServices
{
    private readonly AppDbContext _DbContext;
    private readonly ILogger<ExamServices> _logger;

    public ExamServices(AppDbContext DbContext, ILogger<ExamServices> logger)
    {
        _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
        _logger = logger;
    }

    public IEnumerable<ExamViewModel> GetExamDetails()
    {
        var examDetails = (
                from s in _DbContext.Subjects
                join e in _DbContext.Exams
                    on s.SubjectID equals e.SubjectID
                select new
                {
                    s.SubjectName,
                    e.ExamType,
                    e.ExamDate,
                    e.MaxMarks
                })
            .Select(x => new ExamViewModel
            {
                SubjectName = x.SubjectName,
                ExamType = x.ExamType,
                ExamDate = x.ExamDate,
                MaxMarks = x.MaxMarks
            }).ToList();

        return examDetails;
    }
}