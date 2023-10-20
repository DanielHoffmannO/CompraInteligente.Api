using CompraInteligente.Domain.Entidade;

namespace CompraInteligente.Domain.IServices;

public interface IWsChatGpt
{
    Task<byte> EstimarGpt(string json, byte mes);
    void InjetarComfiguracao(CompraInteligenteConfiguracao config);
}
