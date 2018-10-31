using System;

namespace Qualifica.API.Models
{
    public class ConquistaTrabalhador
    {
        public int id { get; set; }
        public int idAluno { get; set; }
        public int idConquista { get; set; }
        public DateTime Data { get; set; }
    }
}
