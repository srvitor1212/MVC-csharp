using Cerveja.Models;
using Cerveja.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCerveja.Services
{
    public class RotuloService
    {
        private readonly CervejaContext _context;

        public RotuloService(CervejaContext context)
        {
            _context = context;
        }

        //-------------------------------------------------------------------------------
        public List<Rotulo> FindAll()
        {
            var rotulos = _context.Rotulo.ToList();
            return rotulos;
        }
    }
}
