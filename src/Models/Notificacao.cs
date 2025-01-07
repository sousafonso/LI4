using System;

namespace LinhaMontagem.Models
{
    public class Notificacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
    }
}
