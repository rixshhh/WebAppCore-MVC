using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class StudentsController : Controller
{
    //private readonly AppDbContext _data;

    //public StudentsController(AppDbContext data)
    //{
    //    _data = data;
    //}

    public IActionResult Index()
    {
        StudentServices studentServices = new();
        var allStudentDetails = studentServices.GetStudents();
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

        StudentServices addStudent = new();
        var result = addStudent.CreateStudent(students);
        if (result) return RedirectToAction(nameof(Index));
        return View();
    }
}