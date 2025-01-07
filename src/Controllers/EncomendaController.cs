using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinhaMontagem.Data;
using LinhaMontagem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace LinhaMontagem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncomendaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EncomendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(Encomenda encomenda)
        {
            _context.Encomendas.Add(encomenda);
            await _context.SaveChangesAsync();
            return Ok(encomenda);
        }

        [HttpGet("ConsultarHistorico")]
        public async Task<IActionResult> ConsultarHistorico(int clienteId)
        {
            var encomendas = await _context.Encomendas
                .Where(e => e.ClienteId == clienteId)
                .ToListAsync();

            return Ok(encomendas);
        }

        [HttpPost("EfetuarPagamento")]
        public async Task<IActionResult> EfetuarPagamento(int encomendaId)
        {
            var encomenda = await _context.Encomendas
                .Include(e => e.Cliente)
                .Include(e => e.Produtos)
                .ThenInclude(ep => ep.Produto)
                .FirstOrDefaultAsync(e => e.Id == encomendaId);

            if (encomenda == null)
            {
                return NotFound("Encomenda não encontrada.");
            }

            encomenda.CalcularValorTotal();

            return Ok(encomenda);
        }

        [HttpPost("ConfirmarPagamento")]
        public async Task<IActionResult> ConfirmarPagamento(int encomendaId)
        {
            var encomenda = await _context.Encomendas
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(e => e.Id == encomendaId);

            if (encomenda == null)
            {
                return NotFound("Encomenda não encontrada.");
            }

            encomenda.Estado = "Pago";
            await _context.SaveChangesAsync();

            return Ok("Pagamento confirmado.");
        }

        [HttpGet("ConsultarEstado")]
        public async Task<IActionResult> ConsultarEstado(int clienteId)
        {
            var encomendas = await _context.Encomendas
                .Where(e => e.ClienteId == clienteId)
                .ToListAsync();

            return Ok(encomendas);
        }
    }
}
