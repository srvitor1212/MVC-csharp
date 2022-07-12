using Cerveja.Models;
using Cerveja.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCerveja.Services
{
    public class PedidoService
    {
        private readonly CervejaContext _context;

        public PedidoService(CervejaContext context)
        {
            _context = context;
        }

        //-------------------------------------------------------------------------------
        public List<Pedido> FindAll()
        {
            //var pedidos = _context.Pedido.Include(x => x.Vendedor).ToList();
            var pedidos = _context.Pedido.ToList();

            return pedidos;
        }

        //-------------------------------------------------------------------------------
        public List<Pedido> FindAllComplete()
        {
            var pedidos = _context.Pedido.Include(x => x.Vendedor).ToList();
            return pedidos;
        }
    }
}
