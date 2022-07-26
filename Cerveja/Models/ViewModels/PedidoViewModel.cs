using System.ComponentModel.DataAnnotations;

namespace Cerveja.Models.ViewModels
{
    public class PedidoViewModel
    {
        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public double Valor { get; set; }


        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public int VendedorId { get; set; }


        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public int RotuloId { get; set; }


        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public int Quantidade { get; set; }


        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public ICollection<Vendedor> Vendedor { get; set; }
    }
}
