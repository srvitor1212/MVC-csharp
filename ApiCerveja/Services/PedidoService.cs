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

        public List<Pedido> FindAll()
        {
            var pedidos = _context.Pedido.Include(x => x.Vendedor).ToList();

            return pedidos;
        }
    }
}
