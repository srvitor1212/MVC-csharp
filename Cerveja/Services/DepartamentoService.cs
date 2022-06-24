using Cerveja.Models;
using Cerveja.Data;
using System.Linq;

namespace Cerveja.Services
{
    public class DepartamentoService
    {
        private readonly CervejaContext _context;

        public DepartamentoService(CervejaContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();     //Ordenar por nome
        }
    }
}
