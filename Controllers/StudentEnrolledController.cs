using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class StudentEnrolledController : Controller
{
    public IActionResult Index()
    {
        EnrollmentServices enrollmentServices = new();
        var getEnrolledStudents = enrollmentServices.GetEnrolledStudents();
        return View(getEnrolledStudents);
    }
}