using Microsoft.EntityFrameworkCore;
using ServidorPublico.Domain.Entities;

namespace ServidorPublico.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Servidor> Servidores { get; set; } = null!;
    public DbSet<Orgao> Orgaos { get; set; } = null!;
    public DbSet<Lotacao> Lotacoes { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica todas as configurações de entidade do assembly atual
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
