using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        AppDbContext DbContext = new();

        var course = DbContext.Courses
            .Select(c => new Courses
            {
                CourseID = c.CourseID,
                CourseName = c.CourseName,
                CourseCode = c.CourseCode,
                DurationMonths = c.DurationMonths,
                TotalFees = c.TotalFees,
                CreatedAt = c.CreatedAt
            }).ToList();

        var courseSubject = DbContext.Courses
            .Join(DbContext.Subjects,
                c => c.CourseID,
                s => s.CourseID,
                (c, s) => new { c, s })
            .GroupBy(x => x.c.CourseID)
            .Select(g => new CourseSubjectViewModels
            {
                CourseID = g.Key,
                CourseName = g.First().c.CourseName,
                CourseCode = g.First().c.CourseCode,
                TotalFees = g.First().c.TotalFees,
                Subjects = g.Select(x => x.s.SubjectName).ToList()
            })
            .OrderBy(c => c.CourseName)
            .ToList();

        var viewModel = new CourseSubjectPageViewModels
        {
            Courses = course,
            CourseSubjects = courseSubject
        };

        return View(viewModel);
    }
}