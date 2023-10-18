using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CompraInteligente.Domain.Entidade;

namespace CompraInteligente.Persistence.Mappings.Senha;

public class CompraInteligenteConfiguracaoMapping : IEntityTypeConfiguration<CompraInteligenteConfiguracao>
{
    public void Configure(EntityTypeBuilder<CompraInteligenteConfiguracao> builder)
    {
        builder.ToTable("CompraInteligenteConfiguracao");
        builder.HasKey(x => x.Id);

        builder.Property(d => d.EmailCadastro).HasColumnName("EmailCadastro").HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.Property(d => d.ChaveAcesso).HasColumnName("ChaveAcesso").HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.Property(d => d.UrlBase).HasColumnName("UrlBase").HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.Property(d => d.DataCadastro).HasColumnName("DataCadastro").HasColumnType("datetime");
        builder.Property(d => d.DataVigencia).HasColumnName("DataVigencia").HasColumnType("datetime");
    }
}
