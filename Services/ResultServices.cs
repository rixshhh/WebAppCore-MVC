using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class ResultServices
{
    private readonly AppDbContext _DbContext;
    private readonly ILogger<ResultServices> _logger;

    public ResultServices(AppDbContext DbContext, ILogger<ResultServices> logger)
    {
        _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
        _logger = logger;
    }

    public IEnumerable<ResultViewModel> GetResultDetails()
    {
        var results = (
                from r in _DbContext.Results
                join s in _DbContext.Students
                    on r.StudentID equals s.StudentID
                join e in _DbContext.Exams
                    on r.ExamID equals e.ExamID
                join sub in _DbContext.Subjects
                    on e.SubjectID equals sub.SubjectID
                select new
                {
                    StudentName = s.FirstName + " " + s.LastName,
                    sub.SubjectName,
                    r.MarksObtained,
                    e.MaxMarks,
                    r.Grade
                })
            .Select(x => new ResultViewModel
            {
                StudentName = x.StudentName,
                SubjectName = x.SubjectName,
                MarksObtained = x.MarksObtained,
                MaxMarks = x.MaxMarks,
                Grade = x.Grade
            }).ToList();

        return results;
    }
}