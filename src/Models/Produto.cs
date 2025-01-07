using System.Collections.Generic;

namespace LI4.src.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public List<Material> Materiais { get; set; } = new List<Material>();
    }
}
