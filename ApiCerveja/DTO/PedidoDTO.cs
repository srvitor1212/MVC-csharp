using Cerveja.Models;
using Cerveja.Models.Enums;

namespace ApiCerveja.DTO
{
    public class PedidoDTO
    {
        //Pedido
        public int PedidoId { get; set; }
        public DateTime PedidoData { get; set; }
        public double PedidoValor { get; set; }
        public StatusPedido PedidoStatus { get; set; }

        //Vendedor
        public string VendedorNome { get; set; }

        //Itens pedidos
        public List<Rotulo> Rotulos = new List<Rotulo>();

        // FK's
        //public Vendedor Vendedor { get; set; }
        //public int VendedorId { get; set; }
    }
}
