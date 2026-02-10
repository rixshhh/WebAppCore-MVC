using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class AttendenceController : Controller
{
    private readonly AttendenceServices _attendenceServices;

    public AttendenceController(AttendenceServices attendenceServices)
    {
        _attendenceServices = _attendenceServices ?? throw new ArgumentNullException(nameof(AttendenceServices));
    }
    public IActionResult Index()
    {
        var getAttendenceDetails = _attendenceServices.GetAttendenceDetails();
        return View(getAttendenceDetails);
    }
}