using System;

namespace Qualifica.Models
{
    public class Alocacao
    {
        public int id { get; set; }
        public int idPosto { get; set; }
        public int idUsuario { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Termino { get; set; }

    }
}
