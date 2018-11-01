namespace Qualifica.API.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public int? idGerente { get; set; }
        public int? idTrabalhador { get; set; }
    }
}
