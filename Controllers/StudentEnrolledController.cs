using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class StudentEnrolledController : Controller
{
    private readonly EnrollmentServices _enrollmentServices;

    public StudentEnrolledController(EnrollmentServices enrollmentServices)
    {
        _enrollmentServices = enrollmentServices;
    }

    public IActionResult Index()
    {
        var getEnrolledStudents = _enrollmentServices.GetEnrolledStudents();
        return View(getEnrolledStudents);
    }
}