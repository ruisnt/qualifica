using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Qualifica.Models;

namespace Qualifica.Models
{
    public class QualificaContext : DbContext
    {
        public QualificaContext (DbContextOptions<QualificaContext> options)
            : base(options)
        {
        }

        public DbSet<Qualifica.Models.Usuario> Usuario { get; set; }

        public DbSet<Qualifica.Models.Especialidade> Especialidade { get; set; }

        public DbSet<Qualifica.Models.Obra> Obra { get; set; }

        public DbSet<Qualifica.Models.Posto> Posto { get; set; }

        public DbSet<Qualifica.Models.Alocacao> Alocacao { get; set; }
    }
}
