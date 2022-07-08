using Cerveja.Models;
using ApiCerveja.DTO;
using ApiCerveja.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCerveja.Controllers
{
    public class PedidoController : MainController
    {
        private readonly PedidoService _pedidoService;
        private readonly PedidoERotuloService _pedidoERotuloService;
        private readonly RotuloService _rotuloService;

        public PedidoController(
            PedidoService pedidoService,
            PedidoERotuloService pedidoERotuloService,
            RotuloService rotuloService)
        {
            _pedidoService = pedidoService;
            _pedidoERotuloService = pedidoERotuloService;
            _rotuloService = rotuloService;
        }

        //-------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("api/BuscarTodos")]
        public async Task<ActionResult<IEnumerable<Pedido>>> BuscarTodos()
        {
            var pedidos = _pedidoService.FindAll();
            //var pedidos = _pedidoService.FindAllComplete();

            return Ok(pedidos);
        }

        //-------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("api/BuscarTodosCompleto")]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> BuscarTodosCompleto()
        {
        
            var pedidos = _pedidoService.FindAllComplete();
            var pedidoERotulo = _pedidoERotuloService.FindAll();
            var rotulos = _rotuloService.FindAll();

            List<PedidoDTO> ret = new List<PedidoDTO>();

            foreach (var p in pedidos)
            {
                PedidoDTO pDto = new PedidoDTO();
                pDto.PedidoId =     p.Id;
                pDto.PedidoData =   p.Data;
                pDto.PedidoValor =  p.Valor;
                pDto.PedidoStatus = p.Status;
                pDto.VendedorNome = p.Vendedor.Nome;

                List<Rotulo> rotulosPedido = new List<Rotulo>();
                foreach (var pr in pedidoERotulo)
                {
                    if (p.Id == pr.PedidoId)
                    {
                        Rotulo rot = new Rotulo();
                        rot.Id = pr.RotuloId;
                        rot.Nome = "Teste";
                        rotulosPedido.Add(rot);
                    }
                }

                pDto.Rotulos = new(rotulosPedido);
                ret.Add(pDto);
            }
            
            return Ok(ret);
        }
    }
}
