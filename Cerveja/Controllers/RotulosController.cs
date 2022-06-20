using Microsoft.AspNetCore.Mvc;
using Cerveja.Models;

namespace Cerveja.Controllers
{
    public class RotulosController : Controller
    {
        public IActionResult Index()
        {
            List<Rotulo> list = new List<Rotulo>();
            list.Add(new Rotulo { Id = 1, Name = "Skol" });
            list.Add(new Rotulo { Id = 2, Name = "Brahma" });

            return View(list);
        }
    }
}
