using WebApplication2.Data;

namespace WebApplication2.Services
{
    public class ExamServices
    {
        private readonly AppDbContext _DbContext;
        private readonly ILogger<ExamServices> _logger;

        public ExamServices(AppDbContext DbContext, ILogger<ExamServices> logger)
        {
            _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
            _logger = logger;
        }
    }
}
