using Microsoft.AspNetCore.Mvc;
using ProjetoLinhaMontagem.Data;
using ProjetoLinhaMontagem.Models;
using System.Linq;

namespace ProjetoLinhaMontagem.Controllers
{
    public class UtilizadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtilizadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Registar() => View();

        [HttpPost]
        public IActionResult Registar(Utilizador utilizador)
        {
            if (ModelState.IsValid && !_context.Utilizadores.Any(u => u.Username == utilizador.Username))
            {
                if (!utilizador.Username.EndsWith("cl"))
                {
                    ModelState.AddModelError("", "O username deve terminar com 'cl'.");
                    return View(utilizador);
                }

                _context.Utilizadores.Add(utilizador);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Erro ao registar utilizador.");
            return View(utilizador);
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string senha)
        {
            var utilizador = _context.Utilizadores.FirstOrDefault(u => u.Username == username && u.Senha == senha);
            if (utilizador != null)
            {
                TempData["UserId"] = utilizador.Id;
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Credenciais inválidas.");
            return View();
        }

        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Login");
        }
    }
}