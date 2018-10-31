namespace Qualifica.API.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public byte Tipo { get; set; }
    }
}
