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
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Registar")]
        public async Task<IActionResult> Registrar(Cliente cliente)
        {
            if (_context.Clientes.Any(c => c.Email == cliente.Email))
            {
                return BadRequest("Já existe uma conta associada ao email apresentado.");
            }

            if (_context.Clientes.Any(c => c.Username == cliente.Username))
            {
                return BadRequest("O username inserido já está a ser utilizado.");
            }

            if (!cliente.Username.EndsWith("cl"))
            {
                return BadRequest("O username deve terminar com 'cl'.");
            }

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Username == loginModel.Username && c.Senha == loginModel.Senha);

            if (cliente == null)
            {
                return Unauthorized("Credenciais inválidas.");
            }

            // Simulação de autenticação
            return Ok("Login bem-sucedido.");
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            // Simulação de logout
            return Ok("Logout bem-sucedido.");
        }

        [HttpGet("ConsultarNotificacoes")]
        public async Task<IActionResult> ConsultarNotificacoes(int clienteId)
        {
            var notificacoes = await _context.Notificacoes
                .Where(n => n.ClienteId == clienteId)
                .ToListAsync();

            return Ok(notificacoes);
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Senha { get; set; }
        }
    }
}
