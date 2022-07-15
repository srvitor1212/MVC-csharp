using Cerveja.Models;
using Cerveja.Data;

namespace Cerveja.Services
{
    public class RotuloService
    {
        private readonly CervejaContext _context;

        public RotuloService(CervejaContext context)
        {
            _context = context;
        }

        public List<Rotulo> FindAll()
        {
            return _context.Rotulo.OrderBy(x => x.Nome).ToList();     //Ordenar por nome
        }
        public void Insert(Rotulo obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Rotulo FindById(int id)
        {
            return _context.Rotulo.Find(id);
        }
        public void Update(Rotulo obj)
        {
            _context.Rotulo.Update(obj);
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            var obj = _context.Rotulo.Find(id);
            _context.Rotulo.Remove(obj);
            _context.SaveChanges();
        }
    }
}
