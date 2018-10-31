using System;

namespace Qualifica.API.Models
{
    public class Contrato
    {
        public int id { get; set; }
        public int idPosto { get; set; }
        public int idTrabalhador { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Termino { get; set; }
    }
}
