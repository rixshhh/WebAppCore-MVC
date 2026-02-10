using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        AppDbContext DbContext = new();
        var totalStudents = DbContext.Students.Count();
        var totalFaculty = DbContext.Faculty.Count();
        var totalCourses = DbContext.Courses.Count();
        var totalRevenue = DbContext.Fees.Sum(f => f.PaidAmount);


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