namespace LI4.Models
{
    public class LinhaMontagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }

    }

    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int LinhaMontagemId { get; set; }
        public LinhaMontagem LinhaMontagem { get; set; }

    }
}