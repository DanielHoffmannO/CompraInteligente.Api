using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CompraInteligente.Domain.Entidade;

namespace CompraInteligente.Persistence.Mappings.CompraInteligente;

public class CompraInteligenteHistoricoMapping : IEntityTypeConfiguration<CompraInteligenteHistorico>
{
    public void Configure(EntityTypeBuilder<CompraInteligenteHistorico> builder)
    {
        builder.ToTable("CompraInteligenteHistorico");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Produto).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(255);
        builder.Property(c => c.Quantidade).HasColumnName("Quantidade").HasColumnType("int");
        builder.Property(c => c.DataCadastro).HasColumnName("DataCompra").HasColumnType("date");
        builder.Property(c => c.ValorUnidade).HasColumnName("Preco").HasColumnType("decimal(10, 2)");
    }
}