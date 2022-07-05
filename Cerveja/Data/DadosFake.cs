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
                _context.PedidoProdutos.Any() ||
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

            //Relação PEDIDO PRODUTO
            PedidoProduto p1p1 = new PedidoProduto(1, p1, r1, 2);
            PedidoProduto p1p2 = new PedidoProduto(2, p1, r3, 1);
            PedidoProduto p1p3 = new PedidoProduto(3, p1, r4, 3);

            PedidoProduto p2p1 = new PedidoProduto(4, p2, r1, 5);
            PedidoProduto p2p2 = new PedidoProduto(5, p2, r5, 1);

            PedidoProduto p3p1 = new PedidoProduto(6, p3, r2, 2);

            PedidoProduto p4p1 = new PedidoProduto(7, p4, r3, 4);

            PedidoProduto p5p1 = new PedidoProduto(8, p5, r2, 6);
            PedidoProduto p5p2 = new PedidoProduto(9, p5, r4, 7);
            PedidoProduto p5p3 = new PedidoProduto(10, p5, r5, 12);

            PedidoProduto p6p1 = new PedidoProduto(11, p6, r4, 40);

            PedidoProduto p7p1 = new PedidoProduto(12, p7, r5, 60);

            PedidoProduto p8p1 = new PedidoProduto(13, p8, r5, 20);

            PedidoProduto p9p1 = new PedidoProduto(14, p9, r3, 30);
            PedidoProduto p9p2 = new PedidoProduto(15, p9, r4, 40);

            PedidoProduto p10p1 = new PedidoProduto(16, p10, r2, 23);


            _context.Departamento.AddRange(d1, d2, d3);
            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);
            _context.Pedido.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            _context.Rotulo.AddRange(r1, r2, r3, r4, r5);
            _context.PedidoProdutos.AddRange(p1p1, p1p2, p1p3, p2p1, p2p2, p3p1, p4p1, p5p1, p5p2, p5p3, p6p1, p7p1, p8p1, p9p1, p9p2, p10p1);


            _context.SaveChanges();
        }
    }
}
