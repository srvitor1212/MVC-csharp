using Cerveja.Models.Enums;

namespace Cerveja.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public StatusPedido Status { get; set; }
        
        // FK's
        public Vendedor Vendedor { get; set; }
        public int VendedorId { get; set; }


        public Pedido()
        {
        }
        public Pedido(int id, DateTime data, double valor, StatusPedido status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
