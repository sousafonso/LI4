using System.Collections.Generic;

namespace LinhaMontagem.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public List<Material> materiais { get; set; }
    }
}
