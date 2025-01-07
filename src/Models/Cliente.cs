using System.Collections.Generic;

namespace LinhaMontagem.Models
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
        public List<Notificacao> Notificacoes { get; set; }
    }
}
