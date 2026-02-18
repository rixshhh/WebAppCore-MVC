using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class ExamsController : Controller
{
    private readonly ExamServices _examServices;

    public ExamsController(ExamServices examServices)
    {
        _examServices = examServices;
    }

    public IActionResult Index()
    {
        var exams = _examServices.GetExamDetails();
        return View(exams);
    }
}