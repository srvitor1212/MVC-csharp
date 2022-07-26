using Cerveja.Models;
using Cerveja.Models.Enums;

namespace ApiCerveja.DTO
{
    public class RotuloEQuantidade
    {
        public Rotulo Rotulo { get; set; }
        public int Quantidade { get; set; }
    }
}
