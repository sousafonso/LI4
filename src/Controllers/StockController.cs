using Microsoft.AspNetCore.Mvc;
using ProjetoLinhaMontagem.Data;
using ProjetoLinhaMontagem.Models;
using System.Linq;

namespace ProjetoLinhaMontagem.Controllers
{
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var materiais = _context.Materiais.ToList();
            return View(materiais);
        }

        public IActionResult Repor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Repor(int id, int quantidade)
        {
            var material = _context.Materiais.Find(id);
            if (material != null && quantidade > 0)
            {
                material.Quantidade += quantidade;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Dados inválidos.");
            return View();
        }
    }
}