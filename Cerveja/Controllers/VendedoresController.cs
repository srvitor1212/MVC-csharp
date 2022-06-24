using Cerveja.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cerveja.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;

        public VendedoresController(VendedorService vendedorService)
        {
            this._vendedorService = vendedorService;
        }

        public IActionResult Index()
        {
            var list = _vendedorService.FindAll();
            return View(list);
        }
    }
}
