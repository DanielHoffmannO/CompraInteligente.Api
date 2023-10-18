using CompraInteligente.Domain.Entidade;

namespace CompraInteligente.Domain.IServices;

public interface IWsChatGpt
{
    Task<string> ObterPalavrasSimilares(string palavraChave);
    void InjetarComfiguracao(CompraInteligenteConfiguracao config);
}
