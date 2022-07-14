using System.ComponentModel.DataAnnotations;

namespace Cerveja.Models
{
    public class Rotulo
    {
        public int Id { get; set; }
        
        
        [Required(ErrorMessage = "Este campo é Obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O tamanho deve ser entre {2} e {1} ")]
        public string Nome { get; set; }


        public Rotulo()
        {
        }
        public Rotulo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
