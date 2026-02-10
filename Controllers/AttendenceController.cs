using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class AttendenceController : Controller
{
    public IActionResult Index()
    {
        AttendenceServices attendenceServices = new();
        var getAttendenceDetails = attendenceServices.GetAttendenceDetails();
        return View(getAttendenceDetails);
    }
}