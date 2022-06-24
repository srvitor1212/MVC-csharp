﻿using Cerveja.Data;
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

            //todo: aqui eu também não tenho certeza se é a melhor forma de se fazer, mas funciona
            var vendedores = _context.Vendedor.ToList();
            foreach (var v in vendedores)
            {
                var dep = _context.Departamento.Find(v.DepartamentoId);
                v.Departamento = dep;
            }
            //todo: ...

            return vendedores;
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

        public Vendedor FindById(int id)
        {
            //todo: não sei se ta certo
            var vend = _context.Vendedor.FirstOrDefault(obj => obj.Id == id);
            var dep = _context.Departamento.Find(vend.DepartamentoId);
            vend.Departamento = dep;
            return vend;
            //todo: ....

            //return _context.Vendedor.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }
    }
}
