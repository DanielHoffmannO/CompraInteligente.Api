using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CompraInteligente.Domain.Entidade;

public class CompraInteligenteHistorico : Entity<CompraInteligenteHistorico, short>
{
    public string Produto { get; set; }
    public short Quantidade { get; set; }
    public DateTime DataCadastro { get; set; }
    
    [JsonIgnore]
    public decimal ValorUnidade { get; set; }
}
