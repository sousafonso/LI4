using System;
using System.Collections.Generic;

namespace LI4.src.Models
{
    public class Encomenda
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataRequerida { get; set; }
        public DateTime DataEntregaPrevista { get; set; }
        public DateTime? DataEntregaFinal { get; set; }
        public decimal ValorTotal { get; set; }
        public string Estado { get; set; } // Em espera, Em produção, Finalizada
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<EncomendaProduto> Produtos { get; set; } = new List<EncomendaProduto>();

        public void CalcularValorTotal()
        {
            ValorTotal = 0;
            foreach (var produto in Produtos)
            {
                ValorTotal += produto.Produto.Preco * produto.Quantidade;
            }
        }
    }

    public class EncomendaProduto
    {
        public int EncomendaId { get; set; }
        public Encomenda Encomenda { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
