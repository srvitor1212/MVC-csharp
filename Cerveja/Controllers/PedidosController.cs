using Cerveja.Models.ViewModels;
using Cerveja.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cerveja.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;
        private readonly VendedorService _vendedorService;
        public PedidosController(PedidoService pedidoService, VendedorService vendedorService)
        {
            this._pedidoService = pedidoService;
            this._vendedorService = vendedorService;
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
            var vendedores = _vendedorService.FindAll();
            var viewModel = new PedidoFormViewModel { Vendedor = vendedores };
            return View(viewModel);
        }
    }
}
