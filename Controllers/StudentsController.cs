using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    public class StudentsController : Controller
    {

        //private readonly AppDbContext _data;

        //public StudentsController(AppDbContext data)
        //{
        //    _data = data;
        //}

        public IActionResult Index()
        {
            AppDbContext DbContext = new();
            IReadOnlyList<StudentsViewModels> students = DbContext.Students
                    .Select(s => new StudentsViewModels
                    {
                        StudentID = s.StudentID,
                        RollNumber = s.RollNumber,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        DOB = s.DOB,
                        Gender = s.Gender,
                        Email = s.Email,
                        Phone = s.Phone,
                        Address = s.Address,
                        AdmissionDate = s.AdmissionDate,
                        IsActive = s.IsActive,
                        CreatedAt = s.CreatedAt,
                        UpdatedAt = s.UpdatedAt
                    }).ToList();

            return View(students);
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
                    RollNumber = model.RollNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DOB = model.DOB,
                    Gender = model.Gender,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    AdmissionDate = model.AdmissionDate,
                    IsActive = model.IsActive,
                    CreatedAt = DateTime.UtcNow.Date,
                    UpdatedAt = DateTime.UtcNow.Date
                };

                AppDbContext DbContext = new();
                DbContext.Students.Add(student);
                DbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }


    }
}
