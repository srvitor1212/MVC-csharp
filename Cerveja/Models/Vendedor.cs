using System.Linq;

namespace Cerveja.Models

{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Salario { get; set; }
     
        // FK's
        public Departamento Departamento { get; set; } // Isso daqui já cria uma coluna "DepartamentoId" no DB
        public int DepartamentoId { get; set; }


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
