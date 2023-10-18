using CompraInteligente.Domain.Entidade;
using CompraInteligente.Domain.Model;

namespace CompraInteligente.Domain.IApplication;
public interface IConfiguracaoService
{
    CompraInteligenteConfiguracao ObterConfiguracao();
    short AdicionarConfiguracao(ConfiguracaoModel model);
    void AtualizarConfiguracao(short id, ConfiguracaoModel model);
}
