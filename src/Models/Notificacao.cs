namespace LinhaMontagem.Models
{
    public class Notificacao
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataHora { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
