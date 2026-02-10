using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class CoursesController : Controller
{
    private readonly CourseServices _courseServices;

    public CoursesController(CourseServices courseServices)
    {
        _courseServices = courseServices ?? throw new ArgumentNullException(nameof(CourseServices));
    }
    public IActionResult Index()
    {
        var getCourses = _courseServices.GetCourses();
        return View(getCourses);
    }
}