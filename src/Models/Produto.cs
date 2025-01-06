using System;

namespace LI4.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

        public Produto(int id, string nome, decimal preco, int quantidade)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            Preco = novoPreco;
        }

        public void AtualizarQuantidade(int novaQuantidade)
        {
            Quantidade = novaQuantidade;
        }

        public override string ToString()
        {
            return $"Produto: {Nome}, Preço: {Preco:C}, Quantidade: {Quantidade}";
        }
    }
}