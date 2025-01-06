using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLinhaMontagem.Data;
using ProjetoLinhaMontagem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLinhaMontagem.Controllers
{
    public class EncomendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EncomendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var encomendas = await _context.Encomendas
                .Include(e => e.Cliente)
                .Include(e => e.Produtos)
                .ThenInclude(ep => ep.Produto)
                .ToListAsync();
            return View(encomendas);
        }

        public IActionResult Criar()
        {
            ViewBag.Produtos = _context.Produtos.ToList();
            ViewBag.Clientes = _context.Utilizadores.Where(u => u.Tipo == "Cliente").ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Encomenda encomenda, int[] produtos, int[] quantidades)
        {
            if (ModelState.IsValid)
            {
                _context.Encomendas.Add(encomenda);
                for (int i = 0; i < produtos.Length; i++)
                {
                    var produto = _context.Produtos.Find(produtos[i]);
                    if (produto != null)
                    {
                        _context.Entry(new EncomendaProduto
                        {
                            IdProduto = produto.Id,
                            Quantidade = quantidades[i],
                            Produto = produto
                        }).State = EntityState.Added;
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encomenda);
        }

        public IActionResult Detalhes(int id)
        {
            var encomenda = _context.Encomendas
                .Include(e => e.Cliente)
                .Include(e => e.Produtos)
                .ThenInclude(ep => ep.Produto)
                .FirstOrDefault(e => e.Id == id);
            if (encomenda == null)
            {
                return NotFound();
            }
            return View(encomenda);
        }

        public IActionResult IniciarProducao(int id)
        {
            var encomenda = _context.Encomendas
                .Include(e => e.Produtos)
                .ThenInclude(ep => ep.Produto)
                .FirstOrDefault(e => e.Id == id);

            if (encomenda == null || encomenda.Produtos.Any(p => p.Produto.Quantidade < p.Quantidade))
            {
                return NotFound();
            }

            foreach (var produto in encomenda.Produtos)
            {
                produto.Produto.Quantidade -= produto.Quantidade;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EnviarEncomenda(int id)
        {
            var encomenda = _context.Encomendas
                .Include(e => e.Cliente)
                .FirstOrDefault(e => e.Id == id);

            if (encomenda == null)
            {
                return NotFound();
            }

            // Lógica para enviar a encomenda e notificar o cliente
            var notificacao = new Notificacao
            {
                IdCliente = encomenda.Cliente.Id,
                Mensagem = $"Sua encomenda {encomenda.Id} foi enviada.",
                Data = DateTime.Now
            };

            _context.Notificacoes.Add(notificacao);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Historico()
        {
            var userId = (int)TempData["UserId"];
            var encomendas = _context.Encomendas
                .Include(e => e.Cliente)
                .Where(e => e.Cliente.Id == userId)
                .ToList();

            return View(encomendas);
        }

        public IActionResult Estado(int id)
        {
            var encomenda = _context.Encomendas
                .Include(e => e.Cliente)
                .FirstOrDefault(e => e.Id == id);

            if (encomenda == null)
            {
                return NotFound();
            }

            return View(encomenda);
        }

        public IActionResult EfetuarPagamento(int id)
        {
            var encomenda = _context.Encomendas
                .Include(e => e.Cliente)
                .Include(e => e.Produtos)
                .ThenInclude(ep => ep.Produto)
                .FirstOrDefault(e => e.Id == id);

            if (encomenda == null)
            {
                return NotFound();
            }

            encomenda.CalcularValorTotal();

            return View(encomenda);
        }

        [HttpPost]
        public IActionResult ConfirmarPagamento(int id)
        {
            var encomenda = _context.Encomendas
                .Include(e => e.Cliente)
                .FirstOrDefault(e => e.Id == id);

            if (encomenda == null)
            {
                return NotFound();
            }

            // Lógica para confirmar o pagamento
            encomenda.Estado = "Pago";
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ConsultarLinhaMontagem(int id)
        {
            var linhaMontagem = _context.LinhasMontagem
                .Include(lm => lm.Funcionarios)
                .FirstOrDefault(lm => lm.Id == id);

            if (linhaMontagem == null)
            {
                return NotFound();
            }

            return View(linhaMontagem);
        }
    }
}