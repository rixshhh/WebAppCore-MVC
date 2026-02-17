using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/CourseDetails")]
    public class CourseAPIController : ControllerBase
    {
        private readonly CourseServices _courseServices;

        public CourseAPIController(CourseServices courseServices)
        {
            _courseServices = courseServices;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var courses = _courseServices.GetCoursesList();

            return Ok(courses);
        }

        [HttpGet]
        [Route("{CourseID:int}")]
        public IActionResult GetByID(int CourseID)
        {
            var courses = _courseServices.GetCourseById(CourseID);

            return Ok(courses);
        }
    }
}
