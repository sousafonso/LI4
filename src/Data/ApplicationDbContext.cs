public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Encomenda> Encomendas { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Notificacao> Notificacoes { get; set; }
}
