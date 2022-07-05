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

        //-------------------------------------------------------------------------------------
        public List<Departamento> FindAll()
        {
            return _context.Departamento.ToList();
        }

        //-------------------------------------------------------------------------------------
        public Departamento FindById(int id)
        {
            return _context.Departamento.Find(id);
        }

        //-------------------------------------------------------------------------------------
        public string Update(int id, Departamento dep)
        {
            if (!DepartamentoExists(id))
                return "Erro";

            _context.Entry(dep).State = EntityState.Modified;
            try
            { 
                _context.SaveChanges();
            } 
            catch (Exception E)
            {
                var err = Convert.ToString(E);
                return err;
            }

            return "Ok";
        }

        //-------------------------------------------------------------------------------------
        public void Create(Departamento dep)
        {
            _context.Departamento.Add(dep);
            _context.SaveChanges();
        }

        //-------------------------------------------------------------------------------------
        public void Remove(Departamento dep)
        {
            _context.Departamento.Remove(dep);
            _context.SaveChanges();
        }

        //-------------------------------------------------------------------------------------
        private bool DepartamentoExists(int id)
        {
            return (_context.Departamento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
