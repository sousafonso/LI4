using LinhaMontagem.Data;
using LinhaMontagem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinhaMontagem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinhaMontagemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LinhaMontagemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ConsultarLinha")]
        public IActionResult ConsultarLinha(int produtoId)
        {
            var produto = _context.Produtos.Find(produtoId);
            if (produto == null)
                return NotFound("Produto não encontrado.");

            return Ok(new
            {
                Produto = produto.Nome,
                Estado = "Em processamento", // Exemplo
                EtapaAtual = 2, // Simulação
                TempoRestante = "1 hora" // Simulação
            });
        }

        [HttpPost("IniciarProducao")]
        public IActionResult IniciarProducao(int encomendaId)
        {
            var encomenda = _context.Encomendas.Find(encomendaId);
            if (encomenda == null)
                return NotFound("Encomenda não encontrada.");

            encomenda.Estado = "Em produção";
            _context.SaveChanges();
            return Ok("Produção iniciada com sucesso.");
        }
    }
}