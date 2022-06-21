namespace Cerveja.Models

{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Salario { get; set; }
        public Departamento Departamento { get; set; }
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
    }
}
