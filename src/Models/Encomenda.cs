using System;
using System.Collections.Generic;

namespace LinhaMontagem.Models
{
    public class Encomenda
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Estado { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<EncomendaProduto> Produtos { get; set; }

        public void CalcularValorTotal()
        {
            Valor = 0;
            foreach (var produto in Produtos)
            {
                Valor += produto.Produto.Preco * produto.Quantidade;
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
