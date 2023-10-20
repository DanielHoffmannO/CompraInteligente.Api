using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CompraInteligente.Domain.Entidade;

namespace CompraInteligente.Persistence.Mappings.CompraInteligente;

public class CompraInteligenteLogMapping : IEntityTypeConfiguration<CompraInteligenteLog>
{
    public void Configure(EntityTypeBuilder<CompraInteligenteLog> builder)
    {
        builder.ToTable("CompraInteligenteLog");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Data).HasColumnName("Data").HasColumnType("datetime");
        builder.Property(s => s.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(50);
        builder.Property(s => s.Log).HasColumnName("Log").HasColumnType("varchar").HasMaxLength(600);
    }
}

