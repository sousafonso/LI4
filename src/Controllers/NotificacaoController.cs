using Microsoft.AspNetCore.Mvc;
using ProjetoLinhaMontagem.Data;
using ProjetoLinhaMontagem.Models;
using System;
using System.Linq;

namespace ProjetoLinhaMontagem.Controllers
{
    public class NotificacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Enviar(int clienteId)
        {
            ViewBag.ClienteId = clienteId;
            return View();
        }

        [HttpPost]
        public IActionResult Enviar(int clienteId, string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem))
            {
                var notificacao = new Notificacao
                {
                    IdCliente = clienteId,
                    Mensagem = mensagem,
                    Data = DateTime.Now
                };
                _context.Notificacoes.Add(notificacao);
                _context.SaveChanges();
                return RedirectToAction("Index", "Encomenda");
            }
            ModelState.AddModelError("", "Mensagem não pode ser vazia.");
            return View();
        }

        public IActionResult Consultar(int clienteId)
        {
            var notificacoes = _context.Notificacoes
                .Where(n => n.IdCliente == clienteId)
                .OrderByDescending(n => n.Data)
                .ToList();
            return View(notificacoes);
        }
    }
}