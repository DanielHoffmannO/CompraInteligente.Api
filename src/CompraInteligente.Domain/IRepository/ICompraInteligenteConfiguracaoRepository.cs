using Microsoft.EntityFrameworkCore;
using CompraInteligente.Domain.Entidade;

namespace CompraInteligente.Domain.IRepository;
public interface ICompraInteligenteConfiguracaoRepository : IRepository<CompraInteligenteConfiguracao, short>
{
    CompraInteligenteConfiguracao ObterConfiguracaoVigente();
    CompraInteligenteConfiguracao ObterUltimaConfiguracao();
    bool Salvar(CompraInteligenteConfiguracao config);
    bool Atualizar(CompraInteligenteConfiguracao config);
}
