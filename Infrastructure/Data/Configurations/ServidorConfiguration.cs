using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorPublico.Domain.Entities;

namespace ServidorPublico.Infrastructure.Data.Configurations;

public class ServidorConfiguration : IEntityTypeConfiguration<Servidor>
{
    public void Configure(EntityTypeBuilder<Servidor> builder)
    {
        builder.ToTable("Servidores");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(s => s.Telefone)
            .HasMaxLength(20);

        builder.Property(s => s.Email)
            .HasMaxLength(100);

        builder.Property(s => s.Sala)
            .HasMaxLength(20);

        builder.Property(s => s.OrgaoId)
            .IsRequired();

        builder.Property(s => s.LotacaoId)
            .IsRequired();

        builder.Property(s => s.Ativo)
            .HasDefaultValue(true);
    }
}
