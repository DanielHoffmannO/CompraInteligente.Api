using CompraInteligente.Domain.Entidade;

namespace CompraInteligente.Domain.IApplication;
public interface IConfiguracaoProvider
{
    CompraInteligenteConfiguracao ObterConfiguracao();
    void RecarregarConfiguracao();
}
