using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentsCreateController : Controller
    {
        public IActionResult Index()
        {
            AppDbContext DbContext = new();
            IReadOnlyList<StudentsViewModels> students = DbContext.Students
                    .Select(s => new StudentsViewModels
                    {
                        StudentID = s.StudentID,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Gender = s.Gender,
                        Email = s.Email,
                        Address = s.Address
                    }).ToList();

            return View(students);
        }

        private readonly AppDbContext _data;
        public StudentsCreateController(AppDbContext context)
        {
            _data = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentsViewModels model)
        {
            if (ModelState.IsValid)
            {
                var student = new Students
                {
                    StudentID = model.StudentID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Email = model.Email,
                    Address = model.Address
                };

                _data.Students.Add(student);
                _data.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }


    }
}
