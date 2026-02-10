using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers
{
    public sealed class StudentsAPIController : ControllerBase
    {
        private readonly AppDbContext _DbContext;

        public StudentsAPIController(AppDbContext DbContext)
        {
            _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
        }


        [HttpGet]
        [Route("/api/StudentDetails")]
        public IActionResult Get()
        {
            IList<StudentsDTO> Students = _DbContext.Students
            .Select(s => new StudentsDTO
                (
                    s.StudentID,
                    s.RollNumber,
                    s.FirstName,
                    s.LastName,
                    s.DOB,
                    s.Gender,
                    s.Email,
                    s.Phone,
                    s.Address,
                    s.AdmissionDate,
                    s.IsActive,
                    s.CreatedAt
                )).ToList();

            return Ok(Students);
        }
    }
}
