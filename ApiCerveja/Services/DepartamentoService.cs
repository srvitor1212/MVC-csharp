using Cerveja.Models;
using Cerveja.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCerveja.Services
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
            return _context.Departamento.ToList();
        }
    }
}
