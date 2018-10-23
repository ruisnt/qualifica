using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Qualifica.API.Models;

namespace Qualifica.API.Models
{
    public class QualificaAPIContext : DbContext
    {
        public QualificaAPIContext (DbContextOptions<QualificaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Qualifica.API.Models.Usuario> Usuario { get; set; }

        public DbSet<Qualifica.API.Models.Obra> Obra { get; set; }

        public DbSet<Qualifica.API.Models.Alocacao> Alocacao { get; set; }

        public DbSet<Qualifica.API.Models.Especialidade> Especialidade { get; set; }

        public DbSet<Qualifica.API.Models.Posto> Posto { get; set; }
    }
}
