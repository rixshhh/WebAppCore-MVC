using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("/api/AttendenceDetails")]
public class AttendenceAPIController : ControllerBase
{
    private readonly AttendenceServices _attendenceServices;

    public AttendenceAPIController(AttendenceServices attendenceServices)
    {
        _attendenceServices = attendenceServices;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Get()
    {
        var attendenceDetails = _attendenceServices.GetAttendenceDetailList();

        return Ok(attendenceDetails);
    }
}