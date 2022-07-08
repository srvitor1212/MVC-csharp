using ApiCerveja.DTO;
using ApiCerveja.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCerveja.Controllers
{
    [Route("api/pedidos")]
    public class PedidoController : MainController
    {
        private readonly PedidoService _pedidoService;
        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        //-------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var pedidos = _pedidoService.FindAll();

            return Ok(pedidos);
        }
    }
}
