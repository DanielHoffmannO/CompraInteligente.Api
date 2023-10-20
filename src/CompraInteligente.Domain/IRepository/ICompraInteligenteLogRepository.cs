using CompraInteligente.Domain.Entidade;
using Microsoft.EntityFrameworkCore;

namespace CompraInteligente.Domain.IRepository;

public interface ICompraInteligenteLogRepository : IRepository<CompraInteligenteLog, short>
{
    void SalvarLista(List<CompraInteligenteLog> CompraInteligenteLog);
}
