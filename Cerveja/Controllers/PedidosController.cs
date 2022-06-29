using Cerveja.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cerveja.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;
        public PedidosController(PedidoService pedidoService)
        {
            this._pedidoService = pedidoService;
        }

        //---------------------------------------------------------------------------------------------
        public IActionResult Index()
        {
            var list = _pedidoService.FindAll();
            return View(list);
        }

        //---------------------------------------------------------------------------------------------
        public IActionResult Create()
        {
            return View();
        }
    }
}
