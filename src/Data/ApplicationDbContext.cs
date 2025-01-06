using Microsoft.EntityFrameworkCore;
using ProjetoLinhaMontagem.Models;

namespace ProjetoLinhaMontagem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Encomenda> Encomendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<LinhaMontagem> LinhasMontagem { get; set; }
    }
}