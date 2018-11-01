namespace Qualifica.API.Models
{
    public class Conquista
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public int Experiencia { get; set; }
        public int? idCurso { get; set; }
    }
}
