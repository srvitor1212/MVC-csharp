using Microsoft.AspNetCore.Mvc;

namespace Cerveja.Controllers
{
    public class VendedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
