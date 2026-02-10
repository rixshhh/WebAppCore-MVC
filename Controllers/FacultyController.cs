using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class FacultyController : Controller
{
    private readonly FacultyServices _facultyService;

    public FacultyController(FacultyServices facultyServices)
    {
        _facultyService = facultyServices ?? throw new ArgumentNullException(nameof(FacultyServices));
    }
    public IActionResult Index()
    {
        var getFacultyDetails = _facultyService.getFacultyDetails();
        return View(getFacultyDetails);
    }
}