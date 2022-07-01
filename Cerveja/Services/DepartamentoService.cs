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

        //---------------------------------------------------------------------------------------------------------
        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();     //Ordenar por nome
        }

        //---------------------------------------------------------------------------------------------------------
        public void Insert(Departamento dep)
        {
            _context.Add(dep);
            _context.SaveChanges();
        }

        //---------------------------------------------------------------------------------------------------------
        public Departamento FindById(int id)
        {
            return _context.Departamento.Find(id);
        }

        //---------------------------------------------------------------------------------------------------------
        public void Update(Departamento dep)
        {
            _context.Departamento.Update(dep);
            _context.SaveChanges();
        }

        //---------------------------------------------------------------------------------------------------------
        public void Remove(int id)
        {
            var obj = _context.Departamento.Find(id);
            _context.Departamento.Remove(obj);
            _context.SaveChanges();
        }
    }
}
