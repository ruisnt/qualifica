using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualifica.API.Models
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
