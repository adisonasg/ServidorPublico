using Microsoft.EntityFrameworkCore;
using ServidorPublico.Domain.Entities;

namespace ServidorPublico.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Servidor> Servidores { get; set; }

        // Caso tenha outras entidades, adicione os DbSet abaixo
        // public DbSet<OutroTipo> Outros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aqui você pode configurar o mapeamento das entidades
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
