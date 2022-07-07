using Cerveja.Models.Enums;

namespace ApiCerveja.DTO
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public StatusPedido Status { get; set; }

        // FK's
        //public Vendedor Vendedor { get; set; }
        //public int VendedorId { get; set; }
    }
}
