using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;


namespace WebApplication2.Controllers
{
    [Route("api/EnrolledStudents")]
    public class StudentEnrolledAPIController : ControllerBase
    {
        private readonly EnrollmentServices _enrollmentServices;
        public StudentEnrolledAPIController(EnrollmentServices enrollmentServices)
        {
            _enrollmentServices = enrollmentServices;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var enrolledStudents = _enrollmentServices.GetEnrolledStudentList();

            return enrolledStudents is null
                ? Problem("Error while displaying enrolledStudents")
                : Ok(enrolledStudents);
        }
    }
}
