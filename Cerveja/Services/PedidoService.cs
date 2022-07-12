using Microsoft.EntityFrameworkCore;
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

        //---------------------------------------------------------------------------------
        public List<Pedido> FindAll()
        {
            var pedidos = _context.Pedido.Include(x => x.Vendedor).ToList();

            return pedidos;
        }

        //---------------------------------------------------------------------------------
        public void Insert(Pedido pedido, Rotulo rotulo, int qtd)
        {
            _context.Pedido.Add(pedido);
            _context.SaveChanges();

            PedidoRotulos vinculo = new PedidoRotulos(0, pedido, rotulo, qtd);
            _context.PedidoRotulos.Add(vinculo);
            _context.SaveChanges();
        }
    }
}
