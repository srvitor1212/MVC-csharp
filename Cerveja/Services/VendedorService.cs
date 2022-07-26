using Cerveja.Data;
using Cerveja.Models;
using Microsoft.EntityFrameworkCore;

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
            var vendedores = _context.Vendedor.Include(x => x.Departamento).ToList();
            return vendedores;
        }
        public void Insert(Vendedor obj)
        {
            
            //todo: provavelmente existe um jeito mais elegante de se fazer
            //só que sem isso está dando Null em Departamento.Nome
            var dp = _context.Departamento.Find(keyValues: obj.Departamento.Id);
            obj.Departamento = dp;
            //fim da gambiarra

            _context.Add(obj);
            _context.SaveChanges();
        }
        public Vendedor FindById(int id)
        {
            //             |________incluir o obj departamento___________|__pega o primeiro cliente aonde id=id
            var vendedor = _context.Vendedor.Include(x => x.Departamento).FirstOrDefault(obj => obj.Id == id);

            return vendedor;
        }
        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Vendedor vendedor)
        {
            //todo: aqui tive que fazer dnvo pra puxar o Departamento.Nome
            var dp = _context.Departamento.Find(vendedor.Departamento.Id);
            vendedor.Departamento = dp;
            _context.Update(vendedor);
            
            _context.SaveChanges();
        }
    }
}
