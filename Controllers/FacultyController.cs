using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class FacultyController : Controller
{
    public IActionResult Index()
    {
        FacultyServices facultyService = new();
        var getFacultyDetails = facultyService.getFacultyDetails();
        return View(getFacultyDetails);
    }
}