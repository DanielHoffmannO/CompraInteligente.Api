using CompraInteligente.Domain.Entidade;
using CompraInteligente.Domain.Model;

namespace CompraInteligente.Domain.IApplication;

public interface IConfiguracaoService
{
    CompraInteligenteConfiguracao ObterConfiguracao();
    short AdicionarConfiguracao(ConfiguracaoModel model);
}
