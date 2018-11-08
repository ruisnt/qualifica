using System;

namespace Qualifica.API.DTO
{
    public class Obra
    {
        public int id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Termino { get; set; }
        public int idConstrutora { get; set; }
        public int? idGerente { get; set; }
        public string Endereco { get; set; }
        public string Construtora { get; set; }
    }
}
