using Cerveja.Models;
using Cerveja.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCerveja.Services
{
    public class PedidoERotuloService
    {
        private readonly CervejaContext _context;

        public PedidoERotuloService(CervejaContext context)
        {
            _context = context;
        }

        //-------------------------------------------------------------------------------
        public List<PedidoRotulos> FindAll()
        {
            var pedidos = _context.PedidoRotulos.ToList();
            return pedidos;
        }
    }
}
