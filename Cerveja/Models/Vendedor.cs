using System.Linq;

namespace Cerveja.Models

{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Salario { get; set; }
        public Departamento Departamento { get; set; }      // Isso daqui já cria uma coluna "DepartamentoId" no DB
        public int DepartamentoId { get; set; }             //todo: Aparentemente precisa desse cara para puxar do banco de dados o ID
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();


        public Vendedor()
        {
        }
        public Vendedor(int id, string nome, DateTime dataNascimento, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Salario = salario;
            Departamento = departamento;
        }


        public void AddPedido(Pedido ped)
        {
            this.Pedidos.Add(ped);
        }
        public void RemoverPedido(Pedido ped)
        {
            this.Pedidos.Remove(ped);
        }
        public double TotalPedidos(DateTime inicio, DateTime final)
        {
            return this.Pedidos.Where(ped => ped.Data >= inicio && ped.Data <= final).Sum(Ped => Ped.Valor);
        }
    }
}
