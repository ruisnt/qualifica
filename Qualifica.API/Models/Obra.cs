﻿using System;
using System.Collections.Generic;

namespace Qualifica.API.Models
{
    public class Obra
    {
        public int id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Termino { get; set; }
        public int idConstrutora { get; set; }
        public int? idGerente { get; set; }
        public string Endereco { get; set; }
    }
}
