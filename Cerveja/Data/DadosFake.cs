using Cerveja.Models.Enums;
using Cerveja.Models;

namespace Cerveja.Data
{
    public class DadosFake
    {
        private CervejaContext _context;

        public DadosFake(CervejaContext context)
        {
            _context = context;
        }

        public void InserirDadosFake()
        {
            if (_context.Departamento.Any() ||
                _context.Pedido.Any() ||
                _context.Rotulo.Any() ||
                _context.Vendedor.Any())
            {
                return; // O banco já tem dados, não faz nada
            }

            Departamento d1 = new Departamento(1, "Bairro Progresso");
            Departamento d2 = new Departamento(2, "Centro de Blumenau");
            Departamento d3 = new Departamento(3, "Bairro da Velha");

            Vendedor v1 = new Vendedor(1, "Vitor", new DateTime(1993, 11, 25), 1800.0, d1);
            Vendedor v2 = new Vendedor(2, "Maria", new DateTime(1988, 1, 2), 1900.0, d1);
            Vendedor v3 = new Vendedor(3, "Jeff", new DateTime(1999, 3, 20), 1700.0, d1);
            Vendedor v4 = new Vendedor(4, "Crys", new DateTime(2000, 7, 1), 2200.0, d2);
            Vendedor v5 = new Vendedor(5, "Marcela", new DateTime(1990, 10, 8), 2100.0, d2);
            Vendedor v6 = new Vendedor(6, "João", new DateTime(1990, 11, 25), 1800.0, d3);

            Pedido p1 = new Pedido(1, new DateTime(2022, 1, 1), 250.98, StatusPedido.Pendente, v1);
            Pedido p2 = new Pedido(2, new DateTime(2022, 1, 1), 350.98, StatusPedido.Pendente, v1);
            Pedido p3 = new Pedido(3, new DateTime(2022, 1, 1), 240.98, StatusPedido.Pendente, v1);
            Pedido p4 = new Pedido(4, new DateTime(2022, 1, 1), 2150.98, StatusPedido.Cancelado, v2);
            Pedido p5 = new Pedido(5, new DateTime(2022, 1, 1), 1250.98, StatusPedido.Cancelado, v2);
            Pedido p6 = new Pedido(6, new DateTime(2022, 1, 2), 650.98, StatusPedido.Pendente, v2);
            Pedido p7 = new Pedido(7, new DateTime(2022, 1, 2), 256.98, StatusPedido.Pendente, v1);
            Pedido p8 = new Pedido(8, new DateTime(2022, 1, 3), 254.98, StatusPedido.Faturado, v3);
            Pedido p9 = new Pedido(9, new DateTime(2022, 1, 4), 220.98, StatusPedido.Faturado, v1);
            Pedido p10 = new Pedido(10, new DateTime(2022, 1, 5), 2530.98, StatusPedido.Faturado, v4);

            Rotulo r1 = new Rotulo(1, "Skol 600");
            Rotulo r2 = new Rotulo(2, "Skol Lata");
            Rotulo r3 = new Rotulo(3, "Stella LongNeck");
            Rotulo r4 = new Rotulo(4, "Budweiser Lata");
            Rotulo r5 = new Rotulo(5, "Brahma Duplo Malte");

            _context.Departamento.AddRange(d1, d2, d3);
            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);
            _context.Pedido.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            _context.Rotulo.AddRange(r1, r2, r3, r4, r5);


            _context.SaveChanges();
        }
    }
}
