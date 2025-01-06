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
                return NotFound("Produto n�o encontrado.");

            return Ok(new
            {
                Produto = produto.Nome,
                Estado = "Em processamento", // Exemplo
                EtapaAtual = 2, // Simula��o
                TempoRestante = "1 hora" // Simula��o
            });
        }

        [HttpPost("IniciarProducao")]
        public IActionResult IniciarProducao(int encomendaId)
        {
            var encomenda = _context.Encomendas.Find(encomendaId);
            if (encomenda == null)
                return NotFound("Encomenda n�o encontrada.");

            encomenda.Estado = "Em produ��o";
            _context.SaveChanges();
            return Ok("Produ��o iniciada com sucesso.");
        }
    }
}
