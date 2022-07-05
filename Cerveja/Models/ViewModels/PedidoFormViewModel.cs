namespace Cerveja.Models.ViewModels
{
    public class PedidoFormViewModel
    {
        public Pedido Pedido { get; set; }
        public ICollection<Vendedor> Vendedor { get; set; }
        public ICollection<Rotulo> Rotulos { get; set; }
        public ICollection<PedidoProduto> PedidoProdutos { get; set; }
    }
}
