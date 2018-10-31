using System;

namespace Qualifica.API.Models
{
    public class Trabalhador
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
