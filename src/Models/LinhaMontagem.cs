using System.Collections.Generic;

namespace LI4.src.Models
{
    public class LinhaMontagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public string Estado { get; set; } // Em processamento ou Finalizado
    }
}
