using Cerveja.Models;
using Cerveja.Data;

namespace Cerveja.Services
{
    public class PedidoService
    {
        private readonly CervejaContext _context;

        public PedidoService(CervejaContext context)
        {
            _context = context;
        }

        public List<Pedido> FindAll()
        {
            var pedidos = _context.Pedido.ToList();
            foreach (var pedido in pedidos)
            {
                var vend = _context.Vendedor.Find(pedido.VendedorId);
                pedido.Vendedor = vend;
            }
            return pedidos;
        }
    }
}
