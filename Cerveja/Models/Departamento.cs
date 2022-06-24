using System.Linq;

namespace Cerveja.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();


        public Departamento()
        {
        }
        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }


        public void AddVendedor(Vendedor vend)
        {
            this.Vendedores.Add(vend);
        }
        public double TotalPedidos(DateTime inicio, DateTime final)
        {
            return this.Vendedores.Sum(v => v.TotalPedidos(inicio, final));
        }
    }
}
