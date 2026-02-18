using Microsoft.AspNetCore.Mvc;
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
}