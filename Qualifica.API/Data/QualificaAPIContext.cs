using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Qualifica.API.Models
{
    public class QualificaAPIContext : 
    {
        public QualificaAPIContext (DbContextOptions<QualificaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Qualifica.API.Models.Usuario> Usuario { get; set; }
    }
}
