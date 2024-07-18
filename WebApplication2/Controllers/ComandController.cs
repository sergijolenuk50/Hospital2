using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ComandController : Controller
    {
        static List<Comands> comands;

        public ComandController()
        {
            comands = new List<Comands>()
            {
                new Comands() { Id = 100, Date=1968, Name = "дніпропетровське «Дніпро»" },
                new Comands() { Id = 103, Date=1973, Name = "київського «Динамо»" },
                new Comands() { Id = 130, Date=2000, Name = "збірну України"}
            };
        }
        public IActionResult Index()
        {
            return View(comands);
        }
    }
}
