using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorPublico.Domain.Entities;

namespace ServidorPublico.Infrastructure.Data.Configurations;

public class ServidorConfiguration : IEntityTypeConfiguration<Servidor>
{
    public void Configure(EntityTypeBuilder<Servidor> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.Telefone)
               .HasMaxLength(20);

        builder.Property(s => s.Email)
               .HasMaxLength(100);

        builder.Property(s => s.Sala)
               .HasMaxLength(20);

        builder.HasOne(s => s.Orgao)
               .WithMany() // ou .WithMany(o => o.Servidores) se tiver navegação reversa
               .HasForeignKey(s => s.OrgaoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Lotacao)
               .WithMany() // ou .WithMany(l => l.Servidores) se tiver navegação reversa
               .HasForeignKey(s => s.LotacaoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
