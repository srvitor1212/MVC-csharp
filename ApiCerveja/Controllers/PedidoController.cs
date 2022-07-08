using ApiCerveja.DTO;
using ApiCerveja.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCerveja.Controllers
{
    public class PedidoController : MainController
    {
        private readonly PedidoService _pedidoService;
        private readonly PedidoERotuloService _pedidoERotuloService;
        public PedidoController(PedidoService pedidoService, PedidoERotuloService pedidoERotuloService)
        {
            _pedidoService = pedidoService;
            _pedidoERotuloService = pedidoERotuloService;
        }

        //-------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("api/BuscarTodos")]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> BuscarTodos()
        {
            var pedidos = _pedidoService.FindAll();

            return Ok(pedidos);
        }

        //-------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("api/BuscarTodosCompleto")]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> BuscarTodosCompleto()
        {
            var pedidos = _pedidoService.FindAllComplete();
            var pedidoERotulo = _pedidoERotuloService.FindAll();

            return Ok(pedidos);
        }
    }
}
