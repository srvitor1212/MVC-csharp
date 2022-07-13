using Cerveja.Services.Exceptions;
using Cerveja.Models;
using Cerveja.Data;
using Microsoft.EntityFrameworkCore;

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
            if ( !_context.Departamento.Any(d => d.Id == dep.Id) ) // se não encontrar nenhum departament com esse ID
            {
                throw new ServiceNotFoundException("Id não encontrado!");
            }

            try
            {
                _context.Departamento.Update(dep);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)  //excessão do entity framework
            {
                throw new ServiceConcurrencyException(e.Message);
            }
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
