using System.Collections.Generic;

namespace LinhaMontagem.Models
{
    public class LinhaMontagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}