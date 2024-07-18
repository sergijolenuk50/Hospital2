using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class ProbuctsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
