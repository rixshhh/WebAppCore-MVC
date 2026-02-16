using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class FacultyAPIController : ControllerBase
{
    private readonly FacultyServices _facultyServices;

    public FacultyAPIController(FacultyServices facultyServices)
    {
        _facultyServices = facultyServices;
    }

    [HttpGet]
    [Route("/api/FacultyDetails")]
    public IActionResult GetAllFacultyDetails()
    {
        var faculty = _facultyServices.GetAllFacultyDetails();
        return Ok(faculty);
    }

    [HttpGet]
    [Route("/api/FacultyDetails/{FacultyID:int}")]
    public IActionResult GetFacultyDetailsById(int FacultyID)
    {
        var facultyDetailsById = _facultyServices.GetFacultyDetailsById(FacultyID);

        if (facultyDetailsById == null) return NotFound();

        return Ok(facultyDetailsById);
    }


    [HttpPost]
    [Route("/api/FacultyDetails")]
    public IActionResult CreateFaculty([FromBody] CreateFacultyRequestDTO facultyRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = _facultyServices.CreateFacultyRequest(facultyRequest);

        return Ok(result);
    }

    [HttpPut]
    [Route("/api/FacultyDetails/{FacultyID:int}")]
    public IActionResult UpdateFaculty(int FacultyID, [FromBody] CreateFacultyRequestDTO facultyRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var faculty = _facultyServices.UpdateFacultyRequest(FacultyID, facultyRequest);

        return faculty is null ? NotFound() : Ok(faculty);
    }
}