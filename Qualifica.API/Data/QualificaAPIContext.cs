﻿using System;
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

        public DbSet<Qualifica.API.Models.Alocacao> Alocacao { get; set; }

        public DbSet<Qualifica.API.Models.Conquista> Conquista { get; set; }

        public DbSet<Qualifica.API.Models.ConquistaTrabalhador> ConquistaTrabalhador { get; set; }

        public DbSet<Qualifica.API.Models.Construtora> Construtora { get; set; }

        public DbSet<Qualifica.API.Models.Curso> Curso { get; set; }

        public DbSet<Qualifica.API.Models.Especialidade> Especialidade { get; set; }

        public DbSet<Qualifica.API.Models.EspecialidadeTrabalhador> EspecialidadeTrabalhador { get; set; }

        public DbSet<Qualifica.API.Models.GerenteObra> GerenteObra { get; set; }

        public DbSet<Qualifica.API.Models.Obra> Obra { get; set; }

        public DbSet<Qualifica.API.Models.Posto> Posto { get; set; }

        public DbSet<Qualifica.API.Models.Trabalhador> Trabalhador { get; set; }

        public DbSet<Qualifica.API.Models.Usuario> Usuario { get; set; }
    }
}
