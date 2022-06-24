using Cerveja.Data;
using Cerveja.Models;

namespace Cerveja.Services
{
    public class VendedorService
    {
        private readonly CervejaContext _context;

        public VendedorService(CervejaContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }
    }
}
