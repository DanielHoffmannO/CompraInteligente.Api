using CompraInteligente.Domain.Entidade;
using Microsoft.EntityFrameworkCore;

namespace CompraInteligente.Domain.IRepository;

public interface ICompraInteligenteConfiguracaoRepository : IRepository<CompraInteligenteConfiguracao, short>
{
    CompraInteligenteConfiguracao ObterConfiguracaoVigente();
    CompraInteligenteConfiguracao ObterUltimaConfiguracao();
    bool Salvar(CompraInteligenteConfiguracao config);
    bool Atualizar(CompraInteligenteConfiguracao config);
}
