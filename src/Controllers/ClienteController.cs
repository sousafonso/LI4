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
        if (!cliente.Username.StartsWith("cl"))
        {
            return BadRequest("O username deve começar com 'cl'.");
        }

        if (_context.Clientes.Any(c => c.Username == cliente.Username))
        {
            return BadRequest("O username já está em uso.");
        }

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return Ok("Conta criada com sucesso.");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(string username, string senha)
    {
        var cliente = await _context.Clientes
            .FirstOrDefaultAsync(c => c.Username == username && c.Senha == senha);

        if (cliente == null)
        {
            return Unauthorized("Credenciais inválidas.");
        }

        return Ok(cliente);
    }
}
