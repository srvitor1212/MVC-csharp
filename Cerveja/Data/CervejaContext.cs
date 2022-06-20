using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cerveja.Models;

namespace Cerveja.Data
{
    public class CervejaContext : DbContext
    {
        public CervejaContext (DbContextOptions<CervejaContext> options)
            : base(options)
        {
        }

        public DbSet<Cerveja.Models.Rotulo>? Rotulo { get; set; }
    }
}
