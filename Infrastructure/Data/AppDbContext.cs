using Microsoft.EntityFrameworkCore;
using ServidorPublico.API.Domain.Entities;

namespace ServidorPublico.API.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Servidor> Servidores { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
