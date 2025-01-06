using LinhaMontagem.Data;
using LinhaMontagem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinhaMontagem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ListarProdutos")]
        public IActionResult ListarProdutos()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpPost("AdicionarProduto")]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Ok("Produto adicionado com sucesso.");
        }

        [HttpPost("AtualizarEstoque")]
        public IActionResult AtualizarEstoque(int produtoId, int novaQuantidade)
        {
            var produto = _context.Produtos.Find(produtoId);
            if (produto == null)
                return NotFound("Produto não encontrado.");

            produto.QuantidadeEmStock = novaQuantidade;
            _context.SaveChanges();
            return Ok("Estoque atualizado com sucesso.");
        }
    }
}
