using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class FeesServices
    {
        private readonly AppDbContext _DbContext;
        private readonly ILogger<FeesServices> _logger;

        public FeesServices(AppDbContext DbContext, ILogger<FeesServices> logger)
        {
            _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
            _logger = logger;
        }

        public IEnumerable<FeesViewModel> GetFeesDetails()
        {
            var feesDetails = (
                from s in _DbContext.Students
                join f in _DbContext.Fees
                    on s.StudentID equals f.StudentID
                select new
                {
                    StudentName = s.FirstName + " " + s.LastName,
                    f.TotalAmount,
                    f.PaidAmount,
                    f.DueAmount,
                    f.LastPaymentDate,
                    f.Status
                })           // switch to client-side
                .Select(x => new FeesViewModel
                {
                    StudentName = x.StudentName,
                    TotalAmount = x.TotalAmount,
                    PaidAmount = x.PaidAmount,
                    DueAmount = x.DueAmount,
                    LastPaymentDate = x.LastPaymentDate,
                    Status = x.Status
                })
                .ToList();

            return feesDetails;
        }


    }
}

