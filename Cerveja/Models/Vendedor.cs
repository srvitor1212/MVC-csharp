using System.ComponentModel.DataAnnotations;

namespace Cerveja.Models

{
    public class Vendedor
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "O {0} deve ser informado")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O tamanho deve ser entre {2} e {1} ")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Este campo é Obrigatório")]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "Este campo é Obrigatório")]
        [Display(Name = "Salário")]
        public double Salario { get; set; }


        // FK's
        public Departamento Departamento { get; set; } // Isso daqui já cria uma coluna "DepartamentoId" no DB
        [Required(ErrorMessage = "O {0} deve ser informado")]
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
