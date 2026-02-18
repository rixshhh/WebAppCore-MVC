using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services
{
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
            IReadOnlyList<SubjectViewModel> subjects = _DbContext.Subjects
                .Select(s => new SubjectViewModel
                {
                    SubjectID = s.SubjectID,
                    CourseID = s.CourseID,
                    SubjectCode = s.SubjectCode,
                    SubjectName = s.SubjectName,
                    Credits = s.Credits,
                }).ToList();

            return subjects;

        }
    }
}
