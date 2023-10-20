using Microsoft.EntityFrameworkCore;

namespace CompraInteligente.Domain.Entidade;

public class CompraInteligenteHistorico : Entity<CompraInteligenteHistorico, short>
{
    public string Produto { get; set; }
    public short Quantidade { get; set; }
    public DateTime DataCadastro { get; set; }
    public decimal ValorUnidade { get; set; }
}
