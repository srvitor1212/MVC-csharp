using Cerveja.Data;

namespace Cerveja.Services
{
    public class HomeService
    {
        private readonly CervejaContext _context;

        public HomeService(CervejaContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            DadosFake df = new DadosFake(_context);
            df.InserirDadosFake();
        }
    }
}
