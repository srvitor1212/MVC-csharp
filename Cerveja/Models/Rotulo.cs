namespace Cerveja.Models
{
    public class Rotulo
    {
        public int Id { get; set; }
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
