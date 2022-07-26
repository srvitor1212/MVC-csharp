using Cerveja.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cerveja.Models
{
    public class Pedido
    {
        [Display(Name = "Código")]
        public int Id { get; set; }


        [DataType(DataType.Date)]
        public DateTime Data { get; set; }


        [DisplayFormat(DataFormatString = "{0:F2}")]
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
