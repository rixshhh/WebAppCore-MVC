using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class FeesController : Controller
    {
        private readonly FeesServices _feesServices;

        public FeesController(FeesServices feesServices)
        {
            _feesServices = feesServices;
        }
        public IActionResult Index()
        {
            var fees = _feesServices.GetFeesDetails();
            return View(fees);
        }
    }
}
