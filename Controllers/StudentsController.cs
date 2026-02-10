using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class StudentsController : Controller
{
    private readonly StudentServices _studentServices;

    public StudentsController(StudentServices studentServices)
    {
        _studentServices = studentServices;
    }

    public IActionResult Index()
    {
        var allStudentDetails = _studentServices.GetStudents();
        return View(allStudentDetails);
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(StudentsViewModel students)
    {
        if (!ModelState.IsValid) return View(students);

        var result = _studentServices.CreateStudent(students);

        if (result) return RedirectToAction(nameof(Index));

        return View();
    }
}