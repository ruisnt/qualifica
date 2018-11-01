using System.Collections.Generic;

namespace Qualifica.API.Models
{
    public class Posto
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int idEspecialidade { get; set; }
        public int idObra { get; set; }
    }
}
