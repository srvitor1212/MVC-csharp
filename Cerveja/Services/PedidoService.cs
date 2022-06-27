﻿using Cerveja.Models;
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
            return pedidos;
        }
    }
}
