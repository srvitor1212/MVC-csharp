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
        public async Task<ActionResult<IEnumerable<PedidoCompleto>>> BuscarTodosCompleto()
        {
            List<PedidoCompleto> ret = new List<PedidoCompleto>();

            var pedidos = _pedidoService.FindAllComplete();
            var pedidoERotulo = _pedidoERotuloService.FindAll();
            var rotulos = _rotuloService.FindAll();            

            foreach (var p in pedidos)
            {
                PedidoCompleto pDto = new PedidoCompleto();
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
                        if ( rotulos.Exists(r => r.Id == pr.RotuloId) )
                        {
                            var dadosDoRotulo = rotulos.Find(r => r.Id == pr.RotuloId);
                            rot.Id = dadosDoRotulo.Id;
                            rot.Nome = dadosDoRotulo.Nome;
                        } else
                        {
                            rot.Id = 0;
                            rot.Nome = "Não cadastrado";
                        }


                        rotulosPedido.Add(rot);
                    }
                }

                pDto.Rotulos = rotulosPedido;
                ret.Add(pDto);
            }
            
            return Ok(ret);
        }
    }
}
