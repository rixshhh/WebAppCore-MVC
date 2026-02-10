using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        CourseServices courseServices = new();
        var getCourses = courseServices.GetCourses();
        return View(getCourses);
    }
}