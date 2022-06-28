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

        //-------------------------------------------------------------------------------------------------------------
        public List<Vendedor> FindAll()
        {
            //todo: uma gambiarra para inserir dados no banco
            DadosFake df = new DadosFake(_context);
            df.InserirDadosFake();
            //...................................

            var vendedores = _context.Vendedor.Include(x => x.Departamento).ToList();
            return vendedores;
        }

        //-------------------------------------------------------------------------------------------------------------
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

        //-------------------------------------------------------------------------------------------------------------
        public Vendedor FindById(int id)
        {
            //             |________incluir o obj departamento___________|__pega o primeiro cliente aonde id=id
            var vendedor = _context.Vendedor.Include(x => x.Departamento).FirstOrDefault(obj => obj.Id == id);

            return vendedor;
        }

        //-------------------------------------------------------------------------------------------------------------
        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        //-------------------------------------------------------------------------------------------------------------
        public string Update(Vendedor vendedor)
        {
            /*
            var obj = _context.Vendedor.Find(vendedor.Id);
            if (obj == null)
                return "NotFound";  //todo: deve ter uma maneira legal de fazer isso aqui
            */

            vendedor.DepartamentoId = vendedor.Departamento.Id; //todo: tive que fazer para gravar certinho
            _context.Vendedor.Update(vendedor);
            
            _context.SaveChanges(); //todo: DANDO ERRO AQUI
            return "Success";
        }
    }
}
