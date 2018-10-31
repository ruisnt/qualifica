namespace Qualifica.API.Models
{
    public class GerenteObra
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public int idConstrutora { get; set; }
    }
}
