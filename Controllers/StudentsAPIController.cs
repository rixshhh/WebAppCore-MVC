using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public sealed class StudentsAPIController : ControllerBase
{
    private readonly StudentServices _studentServices;

    public StudentsAPIController(StudentServices studentServices)
    {
        _studentServices = studentServices;
    }


    [HttpGet]
    [Route("/api/StudentDetails")]
    public IActionResult Get()
    {
        var Students = _studentServices.GetStudents();

        return Ok(Students);
    }

    [HttpGet]
    [Route("/api/StudentDetails/{StudentID:int}")]
    public IActionResult GetStudentById(int StudentID)
    {
        var student = _studentServices.GetStudentById(StudentID);

        if (student == null) return NotFound();

        return Ok(student);
    }

    [HttpPost]
    [Route("/api/StudentDetails")]
    public IActionResult Create([FromBody] CreateStudentRequestDTO studentRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = _studentServices.CreateStudentRequest(studentRequest);
        return Ok(result);
    }


    [HttpPut]
    [Route("/api/StudentDetails/{StudentID:int}")]
    public IActionResult Update([FromBody] CreateStudentRequestDTO request, int StudentID)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var student = _studentServices.UpdateStudent(StudentID, request);
        return student is null ? NotFound() : Ok(student);
    }
}