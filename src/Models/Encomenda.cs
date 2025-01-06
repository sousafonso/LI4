using System;
using System.Collections.Generic;

namespace LI4.Models
{
    public class Encomenda
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public List<DateTime> DatasEntrega { get; set; } = new List<DateTime>();
        public List<EncomendaProduto> Produtos { get; set; } = new List<EncomendaProduto>();

        public Encomenda(int id, string descricao, DateTime data, decimal valor)
        {
            Id = id;
            Descricao = descricao;
            Data = data;
            Valor = valor;
        }

        public void CalcularValorTotal()
        {
            Valor = 0;
            foreach (var produto in Produtos)
            {
                Valor += produto.Produto.Preco * produto.Quantidade;
            }
        }

        public override string ToString()
        {
            return $"Encomenda [Id={Id}, Descricao={Descricao}, Data={Data}, Valor={Valor}]";
        }
    }

    public class EncomendaProduto
    {
        public int IdEncomenda { get; set; }
        public Encomenda Encomenda { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}