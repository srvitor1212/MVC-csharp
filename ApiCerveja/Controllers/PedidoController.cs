using ApiCerveja.DTO;
using ApiCerveja.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCerveja.Controllers
{
    [Route("api/pedidos")]
    public class PedidoController : MainController
    {
        private readonly PedidoService _pedidoService;

        public async Task<ActionResult<IEnumerable<PedidoDTO>>> BuscarTodos()
        {
            var pedidos = _pedidoService.FindAll();

            return Ok(pedidos);
        }
    }
}
