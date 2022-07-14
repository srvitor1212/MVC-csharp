using System.ComponentModel.DataAnnotations;

namespace Cerveja.Models
{
    public class PedidoRotulos
    {
        public int Id { get; set; }


        public int Quantidade { get; set; }

        // FK's
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }


        public Rotulo Rotulo { get; set; }
        public int RotuloId { get; set; }


        public PedidoRotulos()
        {
        }
        public PedidoRotulos(int id, Pedido pedido, Rotulo rotulo, int quantidade)
        {
            this.Id = id;
            this.Pedido = pedido;
            this.Rotulo = rotulo;
            this.Quantidade = quantidade;
        }
    }
}
