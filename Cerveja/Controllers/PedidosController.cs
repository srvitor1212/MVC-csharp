using Cerveja.Models.Enums;
using Cerveja.Models;
using Cerveja.Models.ViewModels;
using Cerveja.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cerveja.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;
        private readonly VendedorService _vendedorService;
        private readonly RotuloService _rotuloService;
        public PedidosController(   PedidoService pedidoService, 
                                    VendedorService vendedorService,
                                    RotuloService rotuloService)
        {
            this._pedidoService = pedidoService;
            this._vendedorService = vendedorService;
            this._rotuloService = rotuloService;
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
            var viewModel = new PedidoViewModel { Vendedor = vendedores};
            
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PedidoViewModel form)
        {
            var vendedor = _vendedorService.FindById(form.VendedorId);
            var rotulo = _rotuloService.FindById(form.RotuloId);

            if (vendedor == null)
                return Problem("Vendedor inválido!");

            if (rotulo == null)
                return Problem("Rótulo inválido!");

            DateTime dtNow = DateTime.Now;
            Pedido pedido = new Pedido(0, dtNow, form.Valor, StatusPedido.Pendente, vendedor);
            _pedidoService.Insert(pedido, rotulo, form.Quantidade);


            return RedirectToAction(nameof(Index));
        }
    }
}
