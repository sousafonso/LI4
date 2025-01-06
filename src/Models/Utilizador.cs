namespace LI4.Models
{
    public class Utilizador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string ContactoTel { get; set; }
        public string Email { get; set; }
        public string NIF { get; set; }
        public string Tipo { get; set; } // Cliente ou Funcionario
    }
}