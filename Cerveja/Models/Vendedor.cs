using System.ComponentModel.DataAnnotations;

namespace Cerveja.Models

{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
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
