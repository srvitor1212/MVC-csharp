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
            //todo: uma gambiarra para inserir dados no banco
            DadosFake df = new DadosFake(_context);
            df.InserirDadosFake();
            //todo: uma gambiarra para inserir dados no banco

            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            obj.Departamento = _context.Departamento.First(); //todo: temporário só para inserir algum departamento
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
