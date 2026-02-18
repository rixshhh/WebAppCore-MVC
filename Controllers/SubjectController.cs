using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class SubjectController : Controller
{
    private readonly SubjectServices _subjectServices;

    public SubjectController(SubjectServices subjectServices)
    {
        _subjectServices = subjectServices;
    }

    public IActionResult Index()
    {
        var subjectsDetails = _subjectServices.GetSubjects();

        return View(subjectsDetails);
    }
}