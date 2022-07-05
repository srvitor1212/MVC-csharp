using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cerveja.Models;

namespace Cerveja.Data
{
    public class CervejaContext : DbContext
    {
        public CervejaContext (DbContextOptions<CervejaContext> options)
            : base(options)
        {
        }

        public DbSet<Rotulo> Rotulo { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }
    }
}
