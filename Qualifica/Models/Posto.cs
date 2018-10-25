using System.Collections.Generic;

namespace Qualifica.Models
{
    public class Posto
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int idEspecialidade { get; set; }

        public IEnumerable<Alocacao> Alocacoes { get; set; }
    }
}
