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
            
            //todo: provavelmente existe um jeito mais elegante de se fazer
            //todo: só que sem isso está dando Null em Departamento.Nome
            var dp = _context.Departamento.Find(keyValues: obj.Departamento.Id);
            obj.Departamento = dp;
            //todo: fim da gambiarra

            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
