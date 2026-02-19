using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class ResultController : Controller
{
    private readonly ResultServices _resultServices;

    public ResultController(ResultServices resultServices)
    {
        _resultServices = resultServices;
    }

    public IActionResult Index()
    {
        var resultDetails = _resultServices.GetResultDetails();
        return View(resultDetails);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var model = new ResultViewModel
        {
            StudentsList = _resultServices.GetStudentList(),
            SubjectsList = _resultServices.GetSubjectList()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(ResultViewModel model)
    {
        if (ModelState.IsValid) return View(model);

        var result = _resultServices.CreateResult(model);

        if (result) return RedirectToAction(nameof(Index));

        model.StudentsList = _resultServices.GetStudentList();
        model.SubjectsList = _resultServices.GetSubjectList();

        return View();
    }
}