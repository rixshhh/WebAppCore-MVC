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
        StudentsDTO? student = _studentServices.GetStudentById(StudentID);

        if (student == null) return NotFound();

        return Ok(student);
    }

    [HttpPost]
    [Route("/api/StudentDetails")]
    public IActionResult Create([FromBody] CreateStudentRequestDTO studentRequest)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        StudentsDTO? result = _studentServices.CreateStudentRequest(studentRequest);
        return result is null
            ? Problem("There was some problem. See log for more details.")
            : Ok(result);
    }


    [HttpPut]
    [Route("/api/StudentDetails/{StudentID:int}")]
    public IActionResult Update([FromBody] CreateStudentRequestDTO request, int StudentID)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        StudentsDTO? student = _studentServices.UpdateStudent(StudentID, request);
        return student is null
            ? Problem("There was some problem. See log for more details.")
            : Ok(student);
    }

    [HttpPatch]
    [Route("/api/StudentDetails/{StudentID:int}")]
    public IActionResult PartialUpdate([FromBody] PatchStudentStatusRequest request, int StudentID)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        StudentsDTO? patchedStudent = _studentServices.PatchStudent(StudentID, request);
        return patchedStudent is null
            ? Problem("There was some problem. See log for more details.")
            : Ok(patchedStudent);
    }

    [HttpDelete]
    [Route("/api/StudentDetails/{StudentID:int}")]
    public IActionResult Delete(int StudentID)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        StudentsDTO? deletedStudent = _studentServices.DeteleStudent(StudentID);
        return deletedStudent is null
            ? Problem("There was some problem. See log for more details.")
            : Ok(deletedStudent);
    }
}