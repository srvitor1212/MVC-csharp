using Cerveja.Models.Enums;

namespace Cerveja.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public StatusPedido Status { get; set; }
    }
}
