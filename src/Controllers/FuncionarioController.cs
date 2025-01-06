using LinhaMontagem.Data;
using LinhaMontagem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinhaMontagem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GerirStock")]
        public IActionResult GerirStock()
        {
            var materiais = _context.Materiais.ToList();
            return Ok(materiais);
        }

        [HttpPost("AtualizarStock")]
        public IActionResult AtualizarStock(int id, int novaQuantidade)
        {
            var material = _context.Materiais.Find(id);
            if (material == null)
                return NotFound("Material não encontrado.");

            material.QuantidadeEmStock = novaQuantidade;
            _context.SaveChanges();
            return Ok("Stock atualizado com sucesso.");
        }

        [HttpPost("EnviarNotificacao")]
        public IActionResult EnviarNotificacao(int clienteId, string mensagem)
        {
            var notificacao = new Notificacao
            {
                ClienteId = clienteId,
                Mensagem = mensagem,
                DataHora = DateTime.Now
            };
            _context.Notificacoes.Add(notificacao);
            _context.SaveChanges();
            return Ok("Notificação enviada com sucesso.");
        }
    }

    [Authorize(Policy = "Funcionario")]
        [HttpPost("EnviarEncomenda")]
        public IActionResult EnviarEncomenda(int encomendaId)
        {
            var encomenda = _context.Encomendas.Find(encomendaId);
            if (encomenda == null)
                return NotFound("Encomenda não encontrada.");

            encomenda.Estado = "Entregue";
            _context.SaveChanges();

            var notificacao = new Notificacao
            {
                ClienteId = encomenda.ClienteId,
                Mensagem = $"A sua encomenda #{encomenda.Id} foi enviada!",
                DataHora = DateTime.Now
            };
            _context.Notificacoes.Add(notificacao);
            _context.SaveChanges();

            return Ok("Encomenda enviada e cliente notificado.");
        }

    }
