using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            AppDbContext DbContext = new();
            IReadOnlyList<Courses> course = DbContext.Courses
                .Select(c => new Courses
                {
                    CourseID   = c.CourseID,
                    CourseName = c.CourseName,
                    CourseCode = c.CourseCode,
                    DurationMonths = c.DurationMonths,
                    TotalFees = c.TotalFees,
                    CreatedAt = c.CreatedAt
                }).ToList();

            return View(course);
        }
    }
}
