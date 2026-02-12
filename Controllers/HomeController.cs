using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _DbContext;

    public HomeController(AppDbContext DbContext)
    {
        _DbContext = DbContext;
    }

    public IActionResult Index()
    {
        var totalStudents = _DbContext.Students.Count();
        var totalFaculty = _DbContext.Faculty.Count();
        var totalCourses = _DbContext.Courses.Count();
        var totalRevenue = _DbContext.Fees.Sum(f => f.PaidAmount);


        ViewBag.TotalStudents = totalStudents;
        ViewBag.TotalFaculty = totalFaculty;
        ViewBag.TotalCourses = totalCourses;
        ViewBag.TotalRevenues = totalRevenue;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}