using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Cerveja.Models
{
    public class Departamento
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "O {0} deve ser informado")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O tamanho deve ser entre {2} e {1} ")]
        public string Nome { get; set; }


        public Departamento()
        {
        }
        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
