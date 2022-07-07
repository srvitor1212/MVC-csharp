using ApiCerveja.Services;
using Microsoft.AspNetCore.Mvc;
using Cerveja.Models;

namespace ApiCerveja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        //------------------------------------------------------------------------------------------------------
    }
}
