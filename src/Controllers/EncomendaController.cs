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
}
