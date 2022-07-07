namespace Cerveja.Models.ViewModels
{
    public class PedidoViewModel
    {
        public double Valor { get; set; }
        public int VendedorId { get; set; }
        public int RotuloId { get; set; }
        public int Quantidade { get; set; }
        public ICollection<Vendedor> Vendedor { get; set; }
    }
}
