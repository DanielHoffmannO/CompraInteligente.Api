using CompraInteligente.Domain.Dto;

namespace CompraInteligente.Domain.IApplication;

public interface IEstimativaService
{
    Task<List<EstimativaDto>> GerarEstimativa(byte mes);
}
