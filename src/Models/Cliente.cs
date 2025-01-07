using System.Collections.Generic;

namespace LI4.src.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public string NIF { get; set; }
        public List<Encomenda> Encomendas { get; set; } = new List<Encomenda>();
        public List<Notificacao> Notificacoes { get; set; } = new List<Notificacao>();
    }
}
